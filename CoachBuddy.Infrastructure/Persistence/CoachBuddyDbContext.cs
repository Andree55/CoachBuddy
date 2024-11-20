using CoachBuddy.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoachBuddy.Infrastructure.Persistence
{
    public class CoachBuddyDbContext : IdentityDbContext
    {
        public CoachBuddyDbContext(DbContextOptions<CoachBuddyDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientTraining> Trainings { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ClientGroup> ClientGroups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .OwnsOne(c => c.ContactDetails);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Trainings)
                .WithOne(s => s.Client)
                .HasForeignKey(s => s.ClientId);

            modelBuilder.Entity<ClientGroup>()
                .HasKey(cg => new { cg.ClientId, cg.GroupId });

            modelBuilder.Entity<ClientGroup>()
                .HasOne(cg => cg.Client)
                .WithMany(c => c.ClientGroups)
                .HasForeignKey(cg => cg.ClientId);

            modelBuilder.Entity<ClientGroup>()
                .HasOne(cg => cg.Group)
                .WithMany(g => g.ClientGroups)
                .HasForeignKey(cg => cg.GroupId);
        }
    }
}

