using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia.Domain.Entities
{
    public class Devices
    {
        public int DeviceId { get; set; }
        public string? Type { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public DateTime? ProductionYear { get; set; }
        public double? DailyPrice { get; set; }
        public bool? Availability { get; set; }

    }
}
