using System;
using Microsoft.AspNetCore.Mvc;
using src.Controllers.Dtos;

namespace src.Controllers
{

    [Controller]
    [Route("/products")]
    public class ProductsController : ControllerBase
    {
        //List<string> products = new List<string> { "product A", "product B" };
        static List<Product> products = new List<Product> { new Product { Name = "Product A", Price = 100, Sku = "PA" } };

        [HttpGet]
        public IActionResult Get([FromHeader] string name)
        {
            var product = products.Find(item => item.Name == name);

            if (product == null)
                return BadRequest("products not found!");            

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }
            products.Add(product);
            return Ok("Product Created!");
        }
    }
}

