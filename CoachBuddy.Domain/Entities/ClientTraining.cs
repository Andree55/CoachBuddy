using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Domain.Entities
{
    public class ClientTraining
    {
        public int Id  { get; set; }
        public string Description { get; set; } = default!;
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;

        public int ClientId { get; set; } = default!;
        public Client Client { get; set; } = default!;

    }
}
