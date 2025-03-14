using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Domain.Entities;

namespace Wypozyczalnia.Domain.Interfaces
{
    public interface IDeviceRepository
    {
        Task<List<Domain.Entities.Devices>> GetAllAsync();
        Task<Devices?> GetByIdAsync(int deviceId);
        Task UpdateAsync(Devices device);
        Task<List<Devices>> GetUnavailableDevicesAsync();

    }
}
