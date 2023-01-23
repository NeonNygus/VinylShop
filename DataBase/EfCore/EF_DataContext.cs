using Microsoft.EntityFrameworkCore;

namespace VinylShop.EfCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options): base(options) { }
        public DbSet<Vinyl> Vinyls { get; set; }
    }
}
