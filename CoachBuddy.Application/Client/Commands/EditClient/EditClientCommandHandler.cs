using AutoMapper;
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

        public EditClientCommandHandler(IClientRepository clientRepository)
        {
            _repository = clientRepository;
        }
        public async Task<Unit> Handle(EditClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _repository.GetByEncodedName(request.EncodedName!);

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
