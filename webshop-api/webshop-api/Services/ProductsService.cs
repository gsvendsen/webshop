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
    public class ProductsService
    {
        private readonly IProductsRepository productsRepository;

        public ProductsService(IProductsRepository productsRespository)
        {
            this.productsRepository = productsRespository;
        }

        public List<Product> Get()
        {

            return this.productsRepository.Get();

        }

        public Product Get(int id)
        {

            var newsItem = this.productsRepository.Get(id);

            if (newsItem == null)
            {
                return null;
            }

            return newsItem;

        }

        public bool Add(Product product)
        {
            if (product == null)
            {
                return false;
            }

            if (product.Name == null)
            {
                return false;
            }

            if (product.Description == null)
            {
                return false;
            }

            this.productsRepository.Add(product);
            return true;
        }

        public bool Delete(int id)
        {


            using (TransactionScope scope = new TransactionScope())
            {
                var result = this.productsRepository.Get(id);
                if (result == null)
                {
                    return false;
                }

                this.productsRepository.Delete(id);

                scope.Complete();
            }

            return true;

        }
    }
}
