using CoachBuddy.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Queries.GetClientsBySearch
{
    public class GetClientsBySearchQuery: IRequest<PaginatedResult<ClientDto>>
    {
        public string SearchTerm { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetClientsBySearchQuery(string searchTerm, int pageNumber = 1, int pageSize = 10)
        {
            SearchTerm = searchTerm;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
