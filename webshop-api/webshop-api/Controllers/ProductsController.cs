using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webshopapi.Models;
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
    public class ProductsController : ControllerBase
    {

        private readonly string connectionString;
        private readonly ProductsService productsService;

        public ProductsController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ProductsConnectionString");
            this.productsService = new ProductsService(new ProductsRepository(connectionString));

        }

        // GET api/products
        [HttpGet]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]

        public IActionResult Get()
        {
            return Ok(productsService.Get());
        }

        // GET api/products/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var newsItem = productsService.Get(id);

            if (newsItem == null)
            {
                return NotFound();
            }

            return Ok(newsItem);
        }

        // POST api/products/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Post([FromBody]Product product)
        {
            var result = this.productsService.Add(product);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {

            var result = this.productsService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
