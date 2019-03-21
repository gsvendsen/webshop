using System;
using System.Collections.Generic;
using webshopapi.Models;

namespace webshopapi.Services
{
    public interface IProductsService
    {
        bool Delete(int id);
        bool Add(Product product);
        Product Get(int id);
        List<Product> Get();
    }
}
