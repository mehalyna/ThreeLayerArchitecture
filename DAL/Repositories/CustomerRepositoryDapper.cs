using System.Data.SqlClient;
using Common;
using Dapper;

namespace ThreeLayerArchitecture.DAL.Repositories
{
    public class CustomerRepositoryDapper
    {
        private readonly string _connectionString;

        public CustomerRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<Customer>("SELECT * FROM Customers");
            }
        }

        public void AddCustomer(string name, string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)", new { Name = name, Email = email });
            }
        }

        public void UpdateCustomer(int customerId, string name, string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("UPDATE Customers SET Name = @Name, Email = @Email WHERE CustomerId = @CustomerId",
                    new { CustomerId = customerId, Name = name, Email = email });
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM Customers WHERE CustomerId = @CustomerId", new { CustomerId = customerId });
            }
        }
    }
}
