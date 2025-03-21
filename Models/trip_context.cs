using Microsoft.EntityFrameworkCore;
using aspapp.Models;

namespace aspapp.Models
{
    public class trip_context : DbContext
    {
        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public trip_context(DbContextOptions<trip_context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-many relationship between Traveler and Trip
            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Travelers)
                .WithMany(tr => tr.Trips)
                .UsingEntity(j => j.ToTable("TripTraveler"));

            // One-to-many relationship between Guide and Trip
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Guide)
                .WithMany(g => g.Trips)
                .HasForeignKey(t => t.GuideId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
