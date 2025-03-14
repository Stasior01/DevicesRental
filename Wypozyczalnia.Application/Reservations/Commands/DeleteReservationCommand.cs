using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Wypozyczalnia.Application.Reservations.Commands
{
    public class DeleteReservationCommand : IRequest
    {
        public int ReservationId { get; set; }

        public DeleteReservationCommand(int reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
