using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Wypozyczalnia.Domain.Entities;
using Wypozyczalnia.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wypozycalnia.Infrastructure.Persistance;

namespace Wypozyczalnia.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly WypozyczalniaDbContext _context;

        public DeviceRepository(WypozyczalniaDbContext context)
        {
            _context = context;
        }
        public async Task<Devices?> GetByIdAsync(int deviceId)
        {
            return await _context.Devices.FindAsync(deviceId);
        }

        public async Task UpdateAsync(Devices device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Devices>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }
        public async Task<List<Devices>> GetUnavailableDevicesAsync()
        {
            return await _context.Devices
                .Where(d => d.Availability == false)
                .ToListAsync();
        }
    }
}

