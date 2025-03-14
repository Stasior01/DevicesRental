using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Wypozyczalnia.Application.Devices.Queries
{
    public class GetDeviceByIdQuery : IRequest<DeviceDto>
    {
        public int Id { get; set; }

        public GetDeviceByIdQuery(int id)
        {
            Id = id;
        }
    }
}

