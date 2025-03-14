using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Wypozyczalnia.Domain.Interfaces;

namespace Wypozyczalnia.Application.Reservations.Queries
{
    public class GetMyRentalsQueryHandler : IRequestHandler<GetMyRentalsQuery, List<ReservationDto>>
    {
        private readonly IReservationRepository _repository;

        public GetMyRentalsQueryHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ReservationDto>> Handle(GetMyRentalsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _repository.GetReservationsByUserAsync(request.UserId);

            // Mapuj na DTO
            return reservations.Select(r => new ReservationDto
            {
                ReservationId = r.ReservationId,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                Status = r.Status,
                UserId = r.UserId,
                DeviceId = r.DeviceId,
                TotalPrice = r.TotalPrice,
                UserEmail = r.UserEmail // Wyświetlanie emaila, jeśli istnieje
            }).ToList();
        }
    }
}
