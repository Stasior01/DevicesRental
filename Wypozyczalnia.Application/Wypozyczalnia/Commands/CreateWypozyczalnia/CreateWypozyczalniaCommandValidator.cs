using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Wypozyczalnia.Domain.Interfaces;

namespace Wypozyczalnia.Application.Wypozyczalnia.Commands.CreateWypozyczalnia
{
    public class CreateWypozyczalniaCommandValidator : AbstractValidator<CreateWypozyczalniaCommand>
    {
        public CreateWypozyczalniaCommandValidator(IWypozyczalniaRepository repository)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20)
                .Custom((value, context) =>
                {
                    var existingWypozyczalnia = repository.GetByName(value).Result;
                    if (existingWypozyczalnia != null)
                    {
                        context.AddFailure($"{value} is not unique name for rental");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty();

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
