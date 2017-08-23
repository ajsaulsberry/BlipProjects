using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Blip.Entities.Customer;
using Blip.Entities.Geographies;

namespace Blip.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext")
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}