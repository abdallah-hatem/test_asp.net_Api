using test_asp.net_Api.Data;
using test_asp.net_Api.Interfaces;

namespace test_asp.net_Api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public IProductRepository Products { get; private set; }

        public UnitOfWork(AppDbContext db)
        {
            _db = db;

            Products = new ProductRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
