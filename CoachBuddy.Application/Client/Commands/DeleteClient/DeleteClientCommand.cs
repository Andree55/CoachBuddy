using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.Client.Commands.DeleteClient
{
    public class DeleteClientCommand: IRequest
    {
        public int Id { get; set; }
    }
}
