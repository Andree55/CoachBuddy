using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Infrastructure.Persistence
{
    public class CoachBuddyDbContext:DbContext
    {
        public DbSet<Domain.Entities.Client> Clients { get; set; }
    }
}
