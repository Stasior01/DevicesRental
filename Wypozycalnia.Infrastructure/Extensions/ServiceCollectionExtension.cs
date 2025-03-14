using Wypozycalnia.Infrastructure.Persistance;
using Wypozyczalnia.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Domain.Interfaces;
using Wypozyczalnia.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Wypozyczalnia.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WypozyczalniaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Wypozyczalnia")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<WypozyczalniaDbContext>();

            services.AddScoped<WypozyczalniaSeeder>();

            services.AddScoped<IWypozyczalniaRepository, WypozyczalniaRepository>();
        }
    }
}
