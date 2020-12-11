using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftyApp.Models;
using CraftyApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftyApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }
        //[HttpPatch] from [FromBody] now with get and the url query we´r changing the database, products.Json
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get( [FromQuery]string ProductId, [FromQuery]int Rating)
        {
            ProductService.AddRating( ProductId, Rating);
            return Ok();
        }
    }
}
