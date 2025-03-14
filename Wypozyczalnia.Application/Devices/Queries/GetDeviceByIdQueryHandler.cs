using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wypozyczalnia.Domain.Interfaces;
using AutoMapper;

namespace Wypozyczalnia.Application.Devices.Queries
{
    public class GetDeviceByIdQueryHandler : IRequestHandler<GetDeviceByIdQuery, DeviceDto>
    {
        private readonly IDeviceRepository _repository;
        private readonly IMapper _mapper;

        public GetDeviceByIdQueryHandler(IDeviceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeviceDto> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
        {
            var device = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<DeviceDto>(device);
        }
    }
}

