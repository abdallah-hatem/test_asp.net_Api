namespace test_asp.net_Api.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }

        Task Save();
    }
}
