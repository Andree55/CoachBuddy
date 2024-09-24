using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace CoachBuddy.Application.Client.Commands.DeleteClient
{
    public class DeleteClientCommandValidator:AbstractValidator<DeleteClientCommand>
    {
        public DeleteClientCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Client ID must be greater than zero.");
        }

    }
}
