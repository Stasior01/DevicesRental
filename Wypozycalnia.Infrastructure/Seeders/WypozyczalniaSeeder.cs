using Wypozycalnia.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Wypozyczalnia.Infrastructure.Seeders
{
    public class WypozyczalniaSeeder
    {
        private readonly WypozyczalniaDbContext _dbContext;
        public WypozyczalniaSeeder(WypozyczalniaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync()) 
            { 
                if (!_dbContext.Wypozyczalnie.Any())
                {
                    
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
