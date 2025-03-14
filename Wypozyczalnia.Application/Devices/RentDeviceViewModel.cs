using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia.Application.Devices
{
    public class RentDeviceViewModel
    {
        public string? UserId { get; set; }
        public int DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public double DailyPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalPrice { get; set; }
        public bool? Availability { get; set; }
    }
}
