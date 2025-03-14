using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Application.ApplicationUser;
using Wypozyczalnia.Application.Mappings;
using Wypozyczalnia.Application.Wypozyczalnia.Commands.CreateWypozyczalnia;

namespace Wypozyczalnia.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext,  UserContext>();

            services.AddMediatR(typeof(CreateWypozyczalniaCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scoped = provider.CreateScope();
                var userContext = scoped.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new WypozyczalniaMappingProfile(userContext));
            }).CreateMapper()
            );

            services.AddValidatorsFromAssemblyContaining<CreateWypozyczalniaCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
