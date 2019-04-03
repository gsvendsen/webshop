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
    public class OrderItemsService
    {
        private readonly IOrderItemsRepository orderItemsRepository;

        public OrderItemsService(IOrderItemsRepository orderItemsRepository)
        {
            this.orderItemsRepository = orderItemsRepository;
        }

        public List<OrderItem> Get()
        {

            var orderItems = this.orderItemsRepository.Get();

            if (orderItems == null)
            {
                return null;
            }

            return orderItems;

        }

        public bool Add(OrderItem orderItem)
        {
            if (orderItem == null)
            {
                return false;
            }

            this.orderItemsRepository.Add(orderItem);
            return true;
        }
    }
}
