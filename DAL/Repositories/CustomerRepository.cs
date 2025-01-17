using Common;
using DAL;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ThreeLayerArchitecture.DAL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(OrderSystemDbContext context) : base(context) { }

        public async Task<Customer> GetCustomerWithOrdersAsync(int customerId)
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }
    }
}