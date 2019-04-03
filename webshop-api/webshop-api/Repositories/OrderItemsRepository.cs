using System;
using System.Collections.Generic;
using webshop_api.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using System.Transactions;

namespace webshop_api.Repositories
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly string connectionString;

        public OrderItemsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<OrderItem> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<OrderItem>("SELECT * FROM Orderitems").ToList();
            }
        }

        public void Add(OrderItem orderItem)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Orderitems (order_id, product_name, product_quantity, product_description, product_price) VALUES(@Order_id, @Product_name, @Product_quantity, @Product_description, @Product_price)", orderItem);
            }
        }
    }
}
