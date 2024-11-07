using MySql.Data.MySqlClient;

namespace SalesManagement.Models
{
    public static class Database
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=sales_management;User=root;Password=password;";
            return new MySqlConnection(connectionString);
        }
    }
}
