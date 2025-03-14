using Wypozycalnia.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Wypozyczalnia.Infrastructure.Extensions;
using Wypozyczalnia.Infrastructure.Seeders;
using Wypozyczalnia.Infrastructure.Migrations;
using Wypozyczalnia.Infrastructure;
using Wypozyczalnia.Application.Extensions;
using Wypozyczalnia.Domain.Interfaces;
using Wypozyczalnia.Infrastructure.Repositories;
using MediatR;
using Wypozyczalnia.Application.Devices.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// Dodanie warstw infrastruktury i aplikacji
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddMediatR(typeof(UnlockDeviceCommand).Assembly);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<WypozyczalniaSeeder>();
await seeder.Seed();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Home/Error");
app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();