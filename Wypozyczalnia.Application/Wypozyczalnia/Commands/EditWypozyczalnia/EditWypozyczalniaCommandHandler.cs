using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wypozyczalnia.Application.ApplicationUser;
using Wypozyczalnia.Domain.Interfaces;

namespace Wypozyczalnia.Application.Wypozyczalnia.Commands.EditWypozyczalnia
{
    public class EditWypozyczalniaCommandHandler : IRequestHandler<EditWypozyczalniaCommand>
    {
        private readonly IWypozyczalniaRepository _repository;
        private readonly IUserContext _userContext;

        public EditWypozyczalniaCommandHandler(IWypozyczalniaRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditWypozyczalniaCommand request, CancellationToken cancellationToken)
        {
            var wypozyczalnia = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && wypozyczalnia.CreatedById == user.Id;
            if (isEditable)
            {
                return Unit.Value;
            }

            wypozyczalnia.Description = request.Description;
            wypozyczalnia.About = request.About;

            wypozyczalnia.ContactDetails.City = request.City;
            wypozyczalnia.ContactDetails.PhoneNumber = request.PhoneNumber;
            wypozyczalnia.ContactDetails.PostalCode = request.PostalCode;
            wypozyczalnia.ContactDetails.Street = request.Street;
            await _repository.Comit();

            return Unit.Value;
        }
    }
}
