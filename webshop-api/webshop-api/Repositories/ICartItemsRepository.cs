using System;
using System.Collections.Generic;
using webshop_api.Models;

namespace webshop_api.Repositories
{
    public interface ICartItemsRepository
    {
        List<CartItem> Get(int id);
        void Add(CartItem cartItem);
        void Delete(int id);
    }
}
