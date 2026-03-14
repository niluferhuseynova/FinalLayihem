using Feane.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Feane.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Appeareance> Appeareances { get; set; }
        public DbSet<BookTable> BookTables { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<DiscountedProduct> DiscountedProducts { get; set; }
        public DbSet<Dish> Dishes { get; set; }

    }

   
}     

