using CoachBuddy.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Commands.EditClient
{
    public class EditClientCommandValidator:AbstractValidator<EditClientCommand>
    {
        public EditClientCommandValidator()
        {
            RuleFor(c => c.Name)
               .NotEmpty()
               .MinimumLength(2).WithMessage("Name should have at least 2 characters")
               .MaximumLength(20).WithMessage("Name should have maximm of 20 characters");
               
            RuleFor(c => c.Description)
               .NotEmpty().WithMessage("Please enter description");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
