﻿using System;
namespace webshop_api.Models
{
    public class Product
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }

        public Product()
        {
        }
    }
}
