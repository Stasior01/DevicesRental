using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia.Application.Wypozyczalnia.Commands.CreateWypozyczalnia
{
    public class CreateWypozyczalniaCommand : WypozyczalniaDto, IRequest
    {
    }
}
