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
        public CoachBuddyDbContext(DbContextOptions<CoachBuddyDbContext> options):base(options)
        {
            
        }
        public DbSet<Domain.Entities.Client> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Client>()
                .OwnsOne(c => c.ContactDetails);
        }
    }
}
