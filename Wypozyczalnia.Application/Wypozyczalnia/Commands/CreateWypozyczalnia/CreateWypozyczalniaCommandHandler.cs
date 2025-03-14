using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Application.ApplicationUser;
using Wypozyczalnia.Domain.Interfaces;

namespace Wypozyczalnia.Application.Wypozyczalnia.Commands.CreateWypozyczalnia
{
    public class CreateWypozyczalniaCommandHandler : IRequestHandler<CreateWypozyczalniaCommand>
    {
        private readonly IWypozyczalniaRepository _wypozyczalniaRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreateWypozyczalniaCommandHandler(IWypozyczalniaRepository wypozyczalniaRepository, IMapper mapper, IUserContext userContext)
        {
            _wypozyczalniaRepository = wypozyczalniaRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateWypozyczalniaCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Worker, Admin"))
            {
                return Unit.Value;
            }
            var wypozyczalnia = _mapper.Map<Domain.Entities.Wypozyczalnia>(request);
            wypozyczalnia.EncodeName();

            wypozyczalnia.CreatedById = currentUser.Id;

            await _wypozyczalniaRepository.Create(wypozyczalnia);

            return Unit.Value;
        }

    }
}
