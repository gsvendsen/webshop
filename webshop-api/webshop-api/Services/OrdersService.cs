using System;
using System.Collections.Generic;
using webshop_api.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using System.Transactions;
using webshop_api.Repositories;

namespace webshop_api.Services
{
    public class OrdersService
    {
        private readonly IOrdersRepository ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public Order Get(int id)
        {

            var orderItem = this.ordersRepository.Get(id);

            if (orderItem == null)
            {
                return null;
            }

            return orderItem;

        }

        public bool Add(Order order)
        {
            if (order == null)
            {
                return false;
            }

            this.ordersRepository.Add(order);
            return true;
        }

    }
}
