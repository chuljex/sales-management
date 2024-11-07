using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace SalesManagement.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public static List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM products", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = reader.GetInt32("product_id"),
                            Name = reader.GetString("name"),
                            Price = reader.GetDecimal("price"),
                            Stock = reader.GetInt32("stock")
                        });
                    }
                }
            }
            return products;
        }

        public void Save()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO products (name, price, stock) VALUES (@name, @price, @stock)", conn);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@price", Price);
                cmd.Parameters.AddWithValue("@stock", Stock);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
