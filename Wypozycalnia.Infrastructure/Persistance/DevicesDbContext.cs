using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia.Infrastructure.Persistance
{
    public class DevicesDbContext : IdentityDbContext
    {
        public DevicesDbContext(DbContextOptions<DevicesDbContext> options) : base(options)
        {

        }
        public DbSet<Wypozyczalnia.Domain.Entities.Devices> Devices { get; set; }

    }
}
