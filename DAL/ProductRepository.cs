using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public ProductRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbHelper.ExecuteQuery<Product>("SELECT * FROM Products");
        }

        public void AddProduct(string name, decimal price)
        {
            _dbHelper.ExecuteCommand("EXEC AddNewProduct @Name, @Price", new { Name = name, Price = price });
        }

        public void UpdateProductPrice(int productId, decimal price)
        {
            _dbHelper.ExecuteCommand("EXEC UpdateProductPrice @ProductId, @Price", new { ProductId = productId, Price = price });
        }

        public void DeleteProduct(int productId)
        {
            _dbHelper.ExecuteCommand("DELETE FROM Products WHERE ProductId = @ProductId", new { ProductId = productId });
        }
    }
}
