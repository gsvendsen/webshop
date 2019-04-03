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
        private readonly IOrderItemsRepository orderItemsRepository;
        private readonly IProductsRepository productsRepository;
        private readonly ICartItemsRepository cartItemsRepository;


        public OrdersService(IOrdersRepository ordersRepository, IOrderItemsRepository orderItemsRepository, IProductsRepository productsRepository, ICartItemsRepository cartItemsRepository)
        {
            this.ordersRepository = ordersRepository;
            this.orderItemsRepository = orderItemsRepository;
            this.productsRepository = productsRepository;
            this.cartItemsRepository = cartItemsRepository;
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

        // api/order/2   Makes order with Order info from Body and using cart 2
        public int Add(int cart_id, Order order)
        {
            var orderId = this.ordersRepository.Add(order);

            var cartItems = this.cartItemsRepository.Get(cart_id);

            var orderItems = cartItems.Select(cartItem =>
            {
                var productItem = this.productsRepository.Get(cartItem.Product_id);

                return new OrderItem
                {
                    Order_id = orderId,
                    Product_name = productItem.Name,
                    Product_description = productItem.Description,
                    Product_price = productItem.Price,
                    Product_quantity = 1
                };

            }).ToList();

            orderItems.ForEach(orderItem =>
            {
                this.orderItemsRepository.Add(orderItem);
            });

            this.cartItemsRepository.Delete(cart_id);

            return orderId;
        }

    }
}
