using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wypozyczalnia.Domain.Entities;
using Wypozyczalnia.Domain.Interfaces;
using Wypozycalnia.Infrastructure.Persistance;

namespace Wypozyczalnia.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly WypozyczalniaDbContext _context;

        public ReservationRepository(WypozyczalniaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _context.Reservations.ToListAsync();
        }
        public async Task AddAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }
        public async Task<List<Reservation>> GetReservationsByUserAsync(string userId)
        {
            return await _context.Reservations
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }
        public async Task DeleteAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteByIdAsync(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Reservation> GetByIdAsync(int reservationId)
        {
            return await _context.Reservations.FirstOrDefaultAsync(r => r.ReservationId == reservationId);
        }


    }
}
