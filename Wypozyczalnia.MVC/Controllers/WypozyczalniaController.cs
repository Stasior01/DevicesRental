using Microsoft.AspNetCore.Mvc;
using MediatR;
using Wypozyczalnia.Application.Wypozyczalnia.Queries.GetAllWypozyczalnie;
using Wypozyczalnia.Application.Wypozyczalnia.Commands.CreateWypozyczalnia;
using Wypozyczalnia.Application.Wypozyczalnia.Queries.GetWypozyczalniaByEncodedName;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Wypozyczalnia.Application.Wypozyczalnia.Commands.EditWypozyczalnia;
using Wypozyczalnia.Application.Devices.Queries.GetAllDevices;
using Wypozyczalnia.Application.Reservations.Queries;
using Wypozyczalnia.Application.Devices;
using Wypozyczalnia.Application.Reservations.Commands;
using Wypozyczalnia.Application.Devices.Queries;
using System.Data;
using Wypozyczalnia.Application.ApplicationUser;
using System.Security.Claims;
using Wypozyczalnia.Application.Devices.Commands;

namespace Wypozyczalnia.MVC.Controllers
{
    public class WypozyczalniaController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public WypozyczalniaController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Authorize(Roles = "Worker, Admin")]
        public async Task<IActionResult> GetUnavailableDevices()
        {
            var devices = await _mediator.Send(new GetUnavailableDevicesQuery());
            return View(devices);
        }
        [HttpPost]
        [Route("Devices/UnlockDevice")]
        [Authorize(Roles = "Worker, Admin")]
        public async Task<IActionResult> UnlockDevice(int deviceId)
        {
            if (deviceId <= 0)
            {
                return BadRequest("Invalid Device ID.");
            }

            var command = new UnlockDeviceCommand(deviceId);
            await _mediator.Send(command);

            return RedirectToAction("GetUnavailableDevices");
        }

        [Authorize]
        [Route("Reservation/MyRentals")]
        public async Task<IActionResult> MyRentals()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Pobierz UserId aktualnie zalogowanego użytkownika
            var rentals = await _mediator.Send(new GetMyRentalsQuery(userId));
            return View(rentals);
        }

        [HttpPost]
        [Authorize]
        [Route("Reservation/CancelReservation")]
        public async Task<IActionResult> CancelReservation(int reservationId)
        {
            if (reservationId <= 0)
            {
                return BadRequest("Invalid reservation ID.");
            }

            var command = new DeleteReservationCommand(reservationId);
            await _mediator.Send(command);

            return RedirectToAction("MyRentals");
        }


        // List Reservations
        [Authorize(Roles = "Worker, Admin")]
        public async Task<IActionResult> GetAllReservations()
        {
            var reservations = await _mediator.Send(new GetAllReservationsQuery());
            return View(reservations);
        }

        // List of Devices
        [Authorize]
        public async Task<IActionResult> GetAllDevices()
        {
            var devices = await _mediator.Send(new GetAllDevicesQuery());
            return View(devices);
        }

        // Renting Device
        [Authorize]
        public async Task<IActionResult> RentDevice(int id)
        {
            // Pobierz dane urządzenia na podstawie ID
            var device = await _mediator.Send(new GetDeviceByIdQuery(id));

            if (device == null)
            {
                return NotFound();
            }
            if ((bool)device.Availability == false)
            {
                return RedirectToAction("NotAvailable", "Home");
            }

            // Przygotuj model widoku
            var model = new RentDeviceViewModel
            {
                //UserId = 
                DeviceId = device.DeviceId,
                DeviceName = device.Model,
                DailyPrice = device.DailyPrice ?? 0.0 // Obsługa null dla DailyPrice
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ConfirmRentDevice(RentDeviceViewModel model)
        {
            if (model.EndDate <= model.StartDate || (model.EndDate - model.StartDate).Days > 14)
            {
                ModelState.AddModelError("", "Invalid date range. Maximum rental duration is 14 days.");
                return View("RentDevice", model);
            }

            var totalDays = (model.EndDate - model.StartDate).Days;
            var totalPrice = totalDays * model.DailyPrice;

            // Pobranie UserId aktualnie zalogowanego użytkownika
            var currentUserEmail = User.Identity.Name; // Pobierz email zalogowanego użytkownika
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Pobierz ID zalogowanego użytkownika

            // Utworzenie komendy
            var command = new CreateReservationCommand
            {
                DeviceId = model.DeviceId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                TotalPrice = totalPrice,
                UserId = currentUserId, // Przekazanie UserId
                UserEmail = currentUserEmail
            };

            await _mediator.Send(command);

            return RedirectToAction("GetAllDevices");
        }


        // List of Rentals
        [Authorize(Roles = "Worker, Admin")]
        public async Task<IActionResult> Index()
        {
            var wypozczalnie = await _mediator.Send(new GetAllWypozyczalnieQuery());
            return View(wypozczalnie);
        }

        [Authorize(Roles = "Worker, Admin")]
        // Creating Rental
        public IActionResult Creat()
        {
            return View();
        }

        // Displaying Details about Rental
        [Authorize]
        [Route("Wypozyczalnia/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetWypozyczalniaByEncodedNameQuery(encodedName));
            return View(dto);
        }

        // Editing Rental
        [Route("Wypozyczalnia/{encodedName}/Edit")]
        [Authorize(Roles = "Worker, Admin")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetWypozyczalniaByEncodedNameQuery(encodedName));

            if (!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditWypozyczalniaCommand model = _mapper.Map<EditWypozyczalniaCommand>(dto);

            return View(model);
        }

        [HttpPost]
        [Route("Wypozyczalnia/{encodedName}/Edit")]
        [Authorize(Roles = "Worker, Admin")]
        public async Task<IActionResult> Edit(string encodedName, EditWypozyczalniaCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Creat(CreateWypozyczalniaCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        [Route("Home/NotAvailable")]
        public IActionResult NotAvailable()
        {
            return View();
        }
    }
}
