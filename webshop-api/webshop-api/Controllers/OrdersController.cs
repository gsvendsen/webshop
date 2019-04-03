using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webshop_api.Models;
using Newtonsoft.Json;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using webshop_api.Services;
using webshop_api.Repositories;

namespace webshop_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly string connectionString;
        private readonly OrdersService ordersService;

        public OrdersController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.ordersService = new OrdersService(new OrdersRepository(connectionString), new OrderItemsRepository(connectionString), new ProductsRepository(connectionString), new CartItemsRepository(connectionString));

        }

        // GET api/cartitems/2
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<CartItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Get(int id)
        {
            var order = ordersService.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // POST api/orders/2
        [HttpPost("{cart_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post(int cart_id, [FromBody]Order order)
        {
            var result = this.ordersService.Add(cart_id, order);

            return Ok(new { id = result });
        }

    }
}
