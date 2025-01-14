using Common;
using Dapper;
using System.Data.SqlClient;

namespace DAL
{
    public class CustomerRepository
    {
        private readonly DatabaseHelper _dbHelper;

        public CustomerRepository(DatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _dbHelper.ExecuteQuery<Customer>("SELECT * FROM Customers");
        }

        public void AddCustomer(string name, string email)
        {
            _dbHelper.ExecuteCommand("INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)", new { Name = name, Email = email });
        }

        public void UpdateCustomer(int customerId, string name, string email)
        {
            _dbHelper.ExecuteCommand("UPDATE Customers SET Name = @Name, Email = @Email WHERE CustomerId = @CustomerId",
                new { CustomerId = customerId, Name = name, Email = email });
        }

        public void DeleteCustomer(int customerId)
        {
            _dbHelper.ExecuteCommand("DELETE FROM Customers WHERE CustomerId = @CustomerId", new { CustomerId = customerId });
        }
    }
}