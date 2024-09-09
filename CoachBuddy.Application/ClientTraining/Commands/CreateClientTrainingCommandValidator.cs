using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.ClientTraining.Commands
{
    public class CreateClientTrainingCommandValidator:AbstractValidator<CreateClientTrainingCommand>
    {
        public CreateClientTrainingCommandValidator()
        {
            RuleFor(s => s.Date).NotEmpty().NotNull();
            RuleFor(s => s.Description).NotEmpty().NotNull();
            RuleFor(s => s.ClientEncodedName).NotEmpty().NotNull();
        }
    }
}
