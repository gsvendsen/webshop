using System;
using System.Collections.Generic;
using webshop_api.Models;

namespace webshop_api.Repositories
{
    public interface IOrderItemsRepository
    {

        List<OrderItem> Get();
        void Add(OrderItem orderItem);
    }
}
