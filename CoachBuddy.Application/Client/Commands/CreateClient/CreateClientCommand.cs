using MediatR;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Commands.CreateClient
{
    public class CreateClientCommand:ClientDto,IRequest
    {
       
    }
}
