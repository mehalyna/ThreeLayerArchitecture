using Common;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeLayerArchitecture.DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(OrderSystemDbContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByOrderAsync(int orderId)
        {
            return await _context.OrderDetails
                .Where(od => od.OrderId == orderId)
                .Select(od => od.Product)
                .ToListAsync();
        }
    }
}
