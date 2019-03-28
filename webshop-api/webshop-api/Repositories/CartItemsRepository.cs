using System;
using System.Collections.Generic;
using webshop_api.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using System.Transactions;

namespace webshop_api.Repositories
{
    public class CartItemsRepository : ICartItemsRepository
    {
        private readonly string connectionString;

        public CartItemsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<CartItem> Get(int id)
        {

            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<CartItem>("SELECT id, cart_id, product_id FROM Cartitems WHERE cart_id = @id", new { id }).ToList();
            }
        }

        public void Add(CartItem cartItem)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Cartitems (cart_id, product_id) VALUES(@Cart_id, @Product_id)", cartItem);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM Cartitems WHERE cart_id = @id", new { id });

            }
        }
    }
}
