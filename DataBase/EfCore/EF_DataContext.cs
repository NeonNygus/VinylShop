using Microsoft.EntityFrameworkCore;
using VinylShop.Model;

namespace VinylShop.EfCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options): base(options) { }
        public DbSet<Vinyl> Vinyls { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hire> Hires { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
