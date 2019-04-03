using System;
namespace webshop_api.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Order_id { get; set; }
        public string Product_name { get; set; }
        public int Product_quantity { get; set; }
        public string Product_description { get; set; }
        public float Product_price { get; set; }

        public OrderItem()
        {
        }
    }
}
