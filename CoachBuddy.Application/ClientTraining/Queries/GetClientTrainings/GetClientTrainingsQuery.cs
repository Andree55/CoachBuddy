using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.ClientTraining.Queries.GetClientTrainings
{
    public class GetClientTrainingsQuery:IRequest<IEnumerable<ClientTrainingDto>>
    {
        public string EncodedName { get; set; } = default!;
    }
}
