using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Domain.Entities;

namespace Wypozyczalnia.Domain.Interfaces
{
    public interface IWypozyczalniaRepository
    {
        Task Create(Domain.Entities.Wypozyczalnia wypozyczalnia);
        Task<Domain.Entities.Wypozyczalnia?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.Wypozyczalnia>> GetAll();
        Task<Domain.Entities.Wypozyczalnia> GetByEncodedName(string encodedName);
        Task Comit();
    }
}
