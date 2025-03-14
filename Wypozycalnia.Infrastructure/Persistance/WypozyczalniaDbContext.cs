using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Domain.Entities;
using Wypozyczalnia.Infrastructure.Migrations;

namespace Wypozycalnia.Infrastructure.Persistance
{
    public class WypozyczalniaDbContext : IdentityDbContext
    {

        public WypozyczalniaDbContext(DbContextOptions<WypozyczalniaDbContext> options) : base(options)
        {

        }
        public DbSet<Devices> Devices { get; set; }
        public DbSet<Wypozyczalnia.Domain.Entities.Reservation> Reservations { get; set; }
        public DbSet<Wypozyczalnia.Domain.Entities.Wypozyczalnia> Wypozyczalnie { get; set; }
        //public DbSet<Wypozyczalnia.Domain.Entities.Devices> Devices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Wypozyczalnia.Domain.Entities.Wypozyczalnia>()
                .OwnsOne(c => c.ContactDetails);

            modelBuilder.Entity<Reservation>() // Usuń relację z User
                    .HasKey(r => r.ReservationId);
            modelBuilder.Entity<Wypozyczalnia.Domain.Entities.Devices>()
                .ToTable("Devices") // Nazwa istniejącej tabeli w MSSQL
                .HasKey(d => d.DeviceId); // Określenie klucza głównego
        }
    }
}
