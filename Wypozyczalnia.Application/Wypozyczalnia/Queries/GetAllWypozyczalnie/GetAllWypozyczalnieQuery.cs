using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Application.Wypozyczalnia.Commands;

namespace Wypozyczalnia.Application.Wypozyczalnia.Queries.GetAllWypozyczalnie
{
    public class GetAllWypozyczalnieQuery : IRequest<IEnumerable<WypozyczalniaDto>>
    {
    }
}
