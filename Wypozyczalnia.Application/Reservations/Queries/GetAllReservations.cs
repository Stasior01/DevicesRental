using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Wypozyczalnia.Domain.Entities;

namespace Wypozyczalnia.Application.Reservations.Queries
{
    public class GetAllReservationsQuery : IRequest<List<ReservationDto>>
    {
    }
}
