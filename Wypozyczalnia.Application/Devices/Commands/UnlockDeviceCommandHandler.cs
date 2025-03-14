using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Wypozyczalnia.Domain.Interfaces;

namespace Wypozyczalnia.Application.Devices.Commands
{
    public class UnlockDeviceCommandHandler : IRequestHandler<UnlockDeviceCommand>
    {
        private readonly IDeviceRepository _repository;

        public UnlockDeviceCommandHandler(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UnlockDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _repository.GetByIdAsync(request.DeviceId);
            if (device == null)
            {
                throw new ArgumentException($"Device with ID {request.DeviceId} does not exist.");
            }

            device.Availability = true;
            await _repository.UpdateAsync(device);

            return Unit.Value;
        }
    }
}

