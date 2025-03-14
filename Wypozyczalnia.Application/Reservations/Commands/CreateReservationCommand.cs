using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System;

namespace Wypozyczalnia.Application.Reservations.Commands
{
    public class CreateReservationCommand : IRequest
    {
        public int DeviceId { get; set; } // DeviceId jako int
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalPrice { get; set; }
        public string? UserId { get; set; } // UserId jako string
        public string? UserEmail { get; set; }
    }



}

