using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Wypozyczalnia.Domain.Interfaces;
using AutoMapper;

namespace Wypozyczalnia.Application.Devices.Queries
{
    public class GetUnavailableDevicesQueryHandler : IRequestHandler<GetUnavailableDevicesQuery, List<DeviceDto>>
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper _mapper;

        public GetUnavailableDevicesQueryHandler(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DeviceDto>> Handle(GetUnavailableDevicesQuery request, CancellationToken cancellationToken)
        {
            var devices = await _repository.GetUnavailableDevicesAsync();
            return _mapper.Map<List<DeviceDto>>(devices);
        }
    }
}

