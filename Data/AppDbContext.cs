using Microsoft.EntityFrameworkCore;
using test_asp.net_Api.Models;

namespace test_asp.net_Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
