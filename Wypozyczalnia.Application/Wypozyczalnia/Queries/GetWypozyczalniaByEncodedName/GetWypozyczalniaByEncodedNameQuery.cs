using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Application.Wypozyczalnia.Commands;

namespace Wypozyczalnia.Application.Wypozyczalnia.Queries.GetWypozyczalniaByEncodedName
{
    public class GetWypozyczalniaByEncodedNameQuery : IRequest<WypozyczalniaDto>
    {
        public string EncodedName { get; set; }

        public GetWypozyczalniaByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
