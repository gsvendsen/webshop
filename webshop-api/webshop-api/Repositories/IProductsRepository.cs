using System;
using System.Collections.Generic;
using webshop_api.Models;

namespace webshop_api.Repositories
{
    public interface IProductsRepository
    {
        List<Product> Get();
        Product Get(int id);
        void Add(Product product);
        void Delete(int id);
    }
}
