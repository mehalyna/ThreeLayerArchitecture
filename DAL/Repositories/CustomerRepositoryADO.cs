using System.Data.SqlClient;
using Common;

namespace ThreeLayerArchitecture.DAL.Repositories
{
    public class CustomerRepositoryADO
    {
        private readonly string _connectionString;

        public CustomerRepositoryADO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = new List<Customer>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Customers", connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerId = (int)reader["CustomerId"],
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString()
                        });
                    }
                }
            }
            return customers;
        }

        public void AddCustomer(string name, string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)", connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(int customerId, string name, string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Customers SET Name = @Name, Email = @Email WHERE CustomerId = @CustomerId", connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Customers WHERE CustomerId = @CustomerId", connection);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.ExecuteNonQuery();
            }
        }
    }
}