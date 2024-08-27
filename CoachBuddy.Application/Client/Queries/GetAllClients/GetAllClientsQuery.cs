using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Queries.GetAllClients
{
    public class GetAllClientsQuery:IRequest<IEnumerable<ClientDto>>
    {
    }
}
