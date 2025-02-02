using System;
using MySql.Data.MySqlClient;
namespace Course_Management_System
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string server, string database, string user, string password)
        {
            _connectionString = $"server=localhost;database=CourseManagementSystem;user=root;password=;";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}