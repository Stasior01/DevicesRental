﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;

namespace Wypozyczalnia.Application.Devices.Queries
{
    public class GetUnavailableDevicesQuery : IRequest<List<DeviceDto>>
    {
    }
}

