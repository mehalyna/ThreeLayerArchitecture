using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> ExecuteQuery<T>(string query, object? parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<T>(query, parameters);
            }
        }

        public int ExecuteCommand(string query, object? parameters = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Execute(query, parameters);
            }
        }
    }
}
