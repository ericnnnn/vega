using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Persistence
{
    public class VegaDbContext:DbContext
    {
        //public VegaDbContext(string connectionString):base(connectionString)
        public VegaDbContext(DbContextOptions<VegaDbContext> options):base(options)
        {
            //System.Configuration.ConfigurationManager
        }

        public DbSet<Make> Makes {get;set;}
        public DbSet<Feature> Features { get; set; }
    }
}