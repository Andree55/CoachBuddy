using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Queries.GetClientByEncodedName
{
    public class GetClientByEncodedNameQuery:IRequest<ClientDto>
    {
        public string EncodedName { get; set; }
        public GetClientByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
