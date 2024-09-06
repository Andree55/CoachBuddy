using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.ClientTraining.Commands
{
    public class CreateClientTrainingCommand:ClientTrainingDto,IRequest
    {
        public string ClientEncodedName { get; set; } = default!;
    }
}
