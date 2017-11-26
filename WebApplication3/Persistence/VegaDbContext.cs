using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Persistence
{
    public class VegaDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Make> Makes { get; set; }

        public DbSet<Model> Models { get; set; }
        public DbSet<Feature> Features { get; set; }

        //public VegaDbContext(string connectionString):base(connectionString)
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {
            //System.Configuration.ConfigurationManager
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
                new { vf.VehicleId, vf.FeatureId }
            );
        }

    }
}