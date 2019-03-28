using System;
using System.Collections.Generic;
using webshop_api.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using System.Transactions;

namespace webshop_api.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly string connectionString;

        public OrdersRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Order Get(int id)
        {

            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Order>("SELECT * FROM Orders WHERE id = @id", new { id });
            }
        }

        public void Add(Order order)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Orders (customer_name, customer_address, customer_phone, order_date) VALUES(@Customer_name, @Customer_address, @Customer_phone, @Order_date)", order);
            }
        }
    }
}
