using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Wypozyczalnia.Domain.Interfaces;

namespace Wypozyczalnia.Application.Reservations.Queries
{
    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, List<ReservationDto>>
    {
        private readonly IReservationRepository _repository;

        public GetAllReservationsQueryHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _repository.GetAllReservationsAsync();
            // Mapowanie na Dto może być tutaj
            return reservations.ConvertAll(r => new ReservationDto
            {
                ReservationId = r.ReservationId,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                Status = r.Status,
                UserId = r.UserId,
                UserEmail = r.UserEmail,
                DeviceId = r.DeviceId,
                TotalPrice = r.TotalPrice
            });
        }
    }
}
