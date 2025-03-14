﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia.Application.Devices
{
    public class DeviceDto
    {
        public int DeviceId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public DateTime? ProductionYear { get; set; }
        public double? DailyPrice { get; set; }
        public bool? Availability { get; set; }
    }
}

