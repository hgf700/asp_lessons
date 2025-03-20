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
            // Relacja wiele do wielu między Traveler a Trip
            modelBuilder.Entity<Trip>()
                .HasMany(t => t.Travelers)
                .WithMany(tr => tr.Trips)
                .UsingEntity(j => j.ToTable("TripTraveler"));

            // Relacja jeden do wielu między Guide a Trip
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Guide)
                .WithMany(g => g.Trips)
                .HasForeignKey(t => t.GuideId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
    

