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
    public class CartItemsController : ControllerBase
    {

        private readonly string connectionString;
        private readonly CartItemsService cartItemsService;

        public CartItemsController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartItemsService = new CartItemsService(new CartItemsRepository(connectionString));

        }

        // GET api/cartitems/2
        [HttpGet ("{id}")]
        [ProducesResponseType(typeof(List<CartItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult Get(int id)
        {
            var cartItems = cartItemsService.Get(id);

            if (cartItems == null)
            {
                return NotFound();
            }

            if (cartItems.Count == 0)
            {
                return NotFound();
            }

            return Ok(cartItems);
        }

        // POST api/products/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post([FromBody]CartItem cartItem)
        {
            var result = this.cartItemsService.Add(cartItem);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/cartitems/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {

            var result = this.cartItemsService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
