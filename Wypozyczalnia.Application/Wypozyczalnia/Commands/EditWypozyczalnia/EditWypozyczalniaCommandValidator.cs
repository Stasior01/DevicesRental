﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia.Application.Wypozyczalnia.Commands.EditWypozyczalnia
{
    public class EditWypozyczalniaCommandValidator : AbstractValidator<EditWypozyczalniaCommand>
    {
        public EditWypozyczalniaCommandValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty();

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
