using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia.Application.Reservations
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }
        public string UserId { get; set; } // Tylko UserId
        public string UserEmail { get; set; }
        public int DeviceId { get; set; }
        public double TotalPrice { get; set; }
    }




}
