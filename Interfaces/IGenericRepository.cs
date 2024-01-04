namespace test_asp.net_Api.Interfaces
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T?> GetById(int id);

        Task<bool> Add(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(T entity);

        void Save();
    }
}
