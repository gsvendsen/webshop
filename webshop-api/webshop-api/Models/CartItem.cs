using System;
namespace webshop_api.Models
{
    public class CartItem
    {

        public int Id { get; set; }
        public int Cart_id { get; set; }
        public int Product_id { get; set; }

        public CartItem()
        {
        }
    }
}
