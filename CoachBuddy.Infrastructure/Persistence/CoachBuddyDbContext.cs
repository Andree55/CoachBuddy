using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachBuddy.Infrastructure.Persistence
{
    public class CoachBuddyDbContext:IdentityDbContext
    {
        public CoachBuddyDbContext(DbContextOptions<CoachBuddyDbContext> options):base(options)
        {
            
        }
        public DbSet<Domain.Entities.Client> Clients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.Client>()
                .OwnsOne(c => c.ContactDetails);
        }
    }
}
