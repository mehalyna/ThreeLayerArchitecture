using Common;

namespace ThreeLayerArchitecture.DAL.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Product> Products { get; }
        Task SaveAsync();
    }
}
