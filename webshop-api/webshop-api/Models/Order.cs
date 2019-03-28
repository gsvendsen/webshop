using System;
namespace webshop_api.Models
{
    public class Order
    {

        public int Id { get; set; }
        public string Customer_name { get; set; }
        public string Customer_address { get; set; }
        public string Customer_phone { get; set; }
        public string Order_date { get; set; }

        public Order()
        {
        }
    }
}
