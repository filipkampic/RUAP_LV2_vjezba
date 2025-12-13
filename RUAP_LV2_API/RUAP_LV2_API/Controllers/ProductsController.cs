using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RUAP_LV2_API.Models;

namespace RUAP_LV2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Laptop", Category = "IT", Price = 5000 },
            new Product { Id = 2, Name = "Mouse", Category = "IT", Price = 150 }
        };

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
