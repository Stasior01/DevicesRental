using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Wypozyczalnia.Domain.Entities;
using Wypozyczalnia.Domain.Interfaces;

namespace Wypozyczalnia.Application.Reservations.Commands
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IReservationRepository _repository;
        private readonly IDeviceRepository _deviceRepository;

        public CreateReservationCommandHandler(IReservationRepository repository, IDeviceRepository deviceRepository)
        {
            _repository = repository;
            _deviceRepository = deviceRepository;
        }

        public async Task<Unit> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            // Walidacja: Sprawdź, czy urządzenie istnieje
            var device = await _deviceRepository.GetByIdAsync(request.DeviceId);
            if (device == null)
            {
                throw new ArgumentException($"Urządzenie o ID {request.DeviceId} nie istnieje.");
            }

            // Walidacja: Sprawdź dostępność urządzenia
            if (!device.Availability.GetValueOrDefault())
            {
                throw new InvalidOperationException($"Urządzenie o ID {request.DeviceId} jest obecnie niedostępne.");
            }

            // Utworzenie nowej rezerwacji
            var reservation = new Reservation
            {
                DeviceId = request.DeviceId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = "Active",
                TotalPrice = request.TotalPrice,
                UserId = request.UserId, // Przypisanie UserId jako string
                UserEmail = request.UserEmail
            };

            // Zapisz rezerwację w bazie danych
            await _repository.AddAsync(reservation);

            // Aktualizacja dostępności urządzenia
            device.Availability = false;
            await _deviceRepository.UpdateAsync(device);

            return Unit.Value;
        }


    }
}
