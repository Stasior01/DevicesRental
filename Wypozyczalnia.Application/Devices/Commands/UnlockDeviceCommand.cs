using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Wypozyczalnia.Application.Devices.Commands
{
    public class UnlockDeviceCommand : IRequest
    {
        public int DeviceId { get; set; }

        public UnlockDeviceCommand(int deviceId)
        {
            DeviceId = deviceId;
        }
    }
}

