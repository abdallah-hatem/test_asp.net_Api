using Microsoft.EntityFrameworkCore;
using test_asp.net_Api.Data;
using test_asp.net_Api.Interfaces;

namespace test_asp.net_Api.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> _dbSet;

        public GenericRepository(AppDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            Save();

            return true;
        }

        public async Task<T?> GetById(int id)
        {
            var product = await _dbSet.FindAsync(id);
            return product;
        }

        public async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            Save();

            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
