﻿using System;
using System.Collections.Generic;
using webshop_api.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using System.Transactions;

namespace webshop_api.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly string connectionString;

        public ProductsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Product> Get()
        {

            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.Query<Product>("SELECT * FROM Products").ToList();
            }
        }

        public Product Get(int id)
        {

            using (var connection = new MySqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<Product>("SELECT * FROM Products WHERE Id = @id", new { id });
            }
        }

        public void Add(Product product)
        {

            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO Products (Name, Description, Price, Image) VALUES(@name, @description, @price, @image)", product);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM Products WHERE Id = @id", new { id });

            }
        }
    }
}
