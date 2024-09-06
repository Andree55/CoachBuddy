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
        public DbSet<Domain.Entities.ClientTraining> Description { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.Client>()
                .OwnsOne(c => c.ContactDetails);

            modelBuilder.Entity<Domain.Entities.Client>()
                .HasMany(c => c.Trainings)
                .WithOne(s => s.Client)
                .HasForeignKey(s => s.ClientId);
        }
    }
}
