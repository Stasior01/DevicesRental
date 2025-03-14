using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;

namespace Wypozyczalnia.Application.Reservations.Queries
{
    public class GetMyRentalsQuery : IRequest<List<ReservationDto>>
    {
        public string UserId { get; }

        public GetMyRentalsQuery(string userId)
        {
            UserId = userId;
        }
    }
}
