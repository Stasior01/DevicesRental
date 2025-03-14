using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Application.Wypozyczalnia.Commands;
using Wypozyczalnia.Domain.Interfaces;

namespace Wypozyczalnia.Application.Wypozyczalnia.Queries.GetAllWypozyczalnie
{
    public class GetAllWypozyczalnieQueryHandler : IRequestHandler<GetAllWypozyczalnieQuery, IEnumerable<WypozyczalniaDto>>
    {
        private readonly IWypozyczalniaRepository _wypozyczalniaRepository;
        private readonly IMapper _mapper;
        public GetAllWypozyczalnieQueryHandler(IWypozyczalniaRepository wypozyczalniaRepository, IMapper mapper)
        {
            _wypozyczalniaRepository = wypozyczalniaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WypozyczalniaDto>> Handle(GetAllWypozyczalnieQuery request, CancellationToken cancellationToken)
        {
            var wypozyczalnie = await _wypozyczalniaRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<WypozyczalniaDto>>(wypozyczalnie);

            return dtos;
        }
    }
}
