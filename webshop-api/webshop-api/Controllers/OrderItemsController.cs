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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webshop_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {

        private readonly string connectionString;
        private readonly OrderItemsService orderItemsService;

        public OrderItemsController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.orderItemsService = new OrderItemsService(new OrderItemsRepository(connectionString));

        }

        // GET api/cartitems/2
        [HttpGet]
        [ProducesResponseType(typeof(List<CartItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Get()
        {
            var orderItems = orderItemsService.Get();

            return Ok(orderItems);
        }

        // POST api/orderitems/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post([FromBody]OrderItem orderItem)
        {
            var result = this.orderItemsService.Add(orderItem);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
