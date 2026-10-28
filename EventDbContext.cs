using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    public class EventDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate = true");
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Event>(new EventConfig());
            modelBuilder.ApplyConfiguration<Badge>(new BadgeConfig());
            modelBuilder.ApplyConfiguration<OrganizerProfile>(new OrganizerConfig());
        }

        public DbSet<Organizer> Organizers { get; set; } = null!;
        public DbSet<Attendee> Attendees { get; set; } = null!;
    }
}
