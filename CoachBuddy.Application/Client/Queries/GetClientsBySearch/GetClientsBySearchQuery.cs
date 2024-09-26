using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Queries.GetClientsBySearch
{
    public class GetClientsBySearchQuery:IRequest<List<ClientDto>>
    {
        public string SearchTerm { get; set; }
    }
}
