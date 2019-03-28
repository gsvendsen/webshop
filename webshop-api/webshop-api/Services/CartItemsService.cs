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
    public class CartItemsService
    {
        private readonly ICartItemsRepository cartItemsRepository;

        public CartItemsService(ICartItemsRepository cartItemsRepository)
        {
            this.cartItemsRepository = cartItemsRepository;
        }

        public List<CartItem> Get(int id)
        {

            var cartItems = this.cartItemsRepository.Get(id);

            if (cartItems == null)
            {
                return null;
            }

            return cartItems;

        }

        public bool Add(CartItem cartItem)
        {
            if (cartItem == null)
            {
                return false;
            }

            this.cartItemsRepository.Add(cartItem);
            return true;
        }

        public bool Delete(int id)
        {

            using (TransactionScope scope = new TransactionScope())
            {
                var result = this.cartItemsRepository.Get(id);

                if (result == null)
                {
                    return false;
                }

                this.cartItemsRepository.Delete(id);

                scope.Complete();
            }

            return true;

        }
    }
}
