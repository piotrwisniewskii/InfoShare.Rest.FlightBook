using InfoShare.Rest.FlightBook.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfoShare.Rest.FlightBook.API.Database
{
    public class FlightBookContext :DbContext
    {
        public DbSet<Plane> Planes { get; set; }

        public FlightBookContext(DbContextOptions<FlightBookContext>options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plane>().HasKey(x => x.Registration);

            base.OnModelCreating(modelBuilder); 
        }
    }
}
