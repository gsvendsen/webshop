using System;
using System.Collections.Generic;
using webshop_api.Models;

namespace webshop_api.Repositories
{
    public interface IOrdersRepository
    {
        Order Get(int id);
        void Add(Order order);
    }
}
