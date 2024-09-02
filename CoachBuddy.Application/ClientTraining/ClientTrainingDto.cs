using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Application.ClientTraining
{
    public class ClientTrainingDto
    {
        public string Trainings { get; set; } = default!;
        public DateTime Date { get; set; } = default!;
    }
}
