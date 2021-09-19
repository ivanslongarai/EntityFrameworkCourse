using Grocery.Domain;
using Microsoft.EntityFrameworkCore;


namespace Grocery.InfraInstructure.Data
{
    public class GroceryDbContext : DbContext 
    {
        public GroceryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GroceryDbContext).Assembly);
        } 
    }
}
