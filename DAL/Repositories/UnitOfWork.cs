using Common;

namespace ThreeLayerArchitecture.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderSystemDbContext _context;

        public UnitOfWork(OrderSystemDbContext context)
        {
            _context = context;
            Customers = new GenericRepository<Customer>(context);
            Orders = new GenericRepository<Order>(context);
            Products = new GenericRepository<Product>(context);
        }

        public IGenericRepository<Customer> Customers { get; private set; }
        public IGenericRepository<Order> Orders { get; private set; }
        public IGenericRepository<Product> Products { get; private set; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
