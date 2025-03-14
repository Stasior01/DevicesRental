using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wypozyczalnia.Domain.Interfaces;

namespace Wypozyczalnia.Application.Reservations.Commands
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
    {
        private readonly IReservationRepository _repository;

        public DeleteReservationCommandHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _repository.GetByIdAsync(request.ReservationId);
            if (reservation == null)
            {
                throw new ArgumentException($"Reservation with ID {request.ReservationId} does not exist.");
            }

            await _repository.DeleteByIdAsync(request.ReservationId);

            return Unit.Value;
        }
    }
}
