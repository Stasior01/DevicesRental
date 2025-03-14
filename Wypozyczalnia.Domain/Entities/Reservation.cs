using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia.Domain.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }
        public string UserId { get; set; } // Tylko Id użytkownika
        public string? UserEmail { get; set; }
        public int DeviceId { get; set; }
        public double TotalPrice { get; set; }
    }




}
