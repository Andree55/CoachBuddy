using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CoachBuddy.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Commands.EditClient
{
    public class EditClientCommandHandler : IRequestHandler<EditClientCommand>
    {
        private readonly IClientRepository _repository;
        private readonly IUserContext _userContext;

        public EditClientCommandHandler(IClientRepository clientRepository, IUserContext userContext)
        {
            _repository = clientRepository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();

            var isEditable =user != null && (client.CreatedById == user.Id || user.IsInRole("Moderator"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            client.Name = request.Name;
            client.Description=request.Description;
            client.About=request.About;

            client.ContactDetails.City = request.City;
            client.ContactDetails.PhoneNumber = request.PhoneNumber;
            client.ContactDetails.PostalCode = request.PostalCode;
            client.ContactDetails.Street = request.Street;

            await _repository.Commit();

            return Unit.Value;
        }   
    }
}
