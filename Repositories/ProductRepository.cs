using test_asp.net_Api.Data;
using test_asp.net_Api.Interfaces;
using test_asp.net_Api.Models;

namespace test_asp.net_Api.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext db) : base(db)
        {
        }

    }
}