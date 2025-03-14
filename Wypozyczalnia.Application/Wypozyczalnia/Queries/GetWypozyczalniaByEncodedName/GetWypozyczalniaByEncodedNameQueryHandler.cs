using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Application.Wypozyczalnia.Commands;
using Wypozyczalnia.Domain.Interfaces;

namespace Wypozyczalnia.Application.Wypozyczalnia.Queries.GetWypozyczalniaByEncodedName
{
    public class GetWypozyczalniaByEncodedNameQueryHandler : IRequestHandler<GetWypozyczalniaByEncodedNameQuery, WypozyczalniaDto>
    {
        private readonly IWypozyczalniaRepository _wypozyczalniaRepository;
        private readonly IMapper _mapper;
        public GetWypozyczalniaByEncodedNameQueryHandler(IWypozyczalniaRepository wypozyczalniaRepository, IMapper mapper)
        {
            _wypozyczalniaRepository = wypozyczalniaRepository;
            _mapper = mapper;
        }

        public async Task<WypozyczalniaDto> Handle(GetWypozyczalniaByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var wypozyczalnia = await _wypozyczalniaRepository.GetByEncodedName(request.EncodedName);

            var dto = _mapper.Map<WypozyczalniaDto>(wypozyczalnia);

            return dto;
        }
    }
}
