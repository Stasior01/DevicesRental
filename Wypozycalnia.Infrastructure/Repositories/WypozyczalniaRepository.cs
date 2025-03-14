using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozycalnia.Infrastructure.Persistance;
using Wypozyczalnia.Domain.Entities;
using Wypozyczalnia.Domain.Interfaces;

namespace Wypozyczalnia.Infrastructure.Repositories
{
    internal class WypozyczalniaRepository : IWypozyczalniaRepository
    {
        private readonly WypozyczalniaDbContext _dbContext;
        public WypozyczalniaRepository(WypozyczalniaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Domain.Entities.Wypozyczalnia wypozyczalnia)
        {
            _dbContext.Add(wypozyczalnia);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Wypozyczalnia>> GetAll()
            => await _dbContext.Wypozyczalnie.ToListAsync();

        public Task<Domain.Entities.Wypozyczalnia?> GetByName(string name)
        => _dbContext.Wypozyczalnie.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());

        public async Task<Domain.Entities.Wypozyczalnia> GetByEncodedName(string encodedName)
        => await _dbContext.Wypozyczalnie.FirstAsync(c => c.EncodedName == encodedName);

        public Task Comit()
        => _dbContext.SaveChangesAsync();

        public Task<List<Devices>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
