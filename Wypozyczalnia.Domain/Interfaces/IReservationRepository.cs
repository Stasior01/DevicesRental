using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wypozyczalnia.Domain.Entities;

namespace Wypozyczalnia.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllAsync();
        Task AddAsync(Reservation reservation);
        Task<List<Reservation>> GetAllReservationsAsync();
        Task<List<Reservation>> GetReservationsByUserAsync(string userId);
        Task DeleteAsync(int reservationId);
        Task DeleteByIdAsync(int reservationId);
        Task<Reservation> GetByIdAsync(int reservationId);
    }
}
