using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Javascript_and_Web_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Javascript_and_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id=1006368,
                Name="Austin and Barbeque AABQ Wifi Food Thermometer",
                Description="Termometer med Wifi for en optimal innertemperatur",
                Price=399
            },
            new Product
            {
                Id=1009334,
                Name="Andersson Elektrisk tander ECL 1.1",
                Description="Elektrisk stormsaker tander helt utan gas och bransle",
                Price=89
            },
            new Product
            {
                Id=1002266,
                Name="Weber Non-Stick Spray",
                Description="BBQ-oljespray som motverkar att ravaror fastnar pa gallret",
                Price=99
            }
        };
        //Get all products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return products;
        }

        //Get specific product
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        //Add new product
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            if (products.Exists(p => p.Id == product.Id))
            {
                return Conflict();
            }
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, products);
        }

        //Delete the product
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Product>> Delete(int id)
        {
            var product = products.Where(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products = products.Except(product).ToList();
            return products;
        }

        //Update product
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Product>> Put(int id, [FromBody]Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            var existingProduct = products.Where(p => p.Id == id);
            products = products.Except(existingProduct).ToList();
            products.Add(product);
            return products;
        }
    }
}