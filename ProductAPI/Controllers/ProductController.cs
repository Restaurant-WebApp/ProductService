using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProductAPI.Model;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
               new Product{ ProductID = 0, ProductName = "Chicken Curry", ProductDescription = "Delicious chicken curry", ProductCategory = "Mains", ProductImage = "image1" },
               new Product{ ProductID = 1, ProductName = "Momos", ProductDescription = "Delicious momo", ProductCategory = "Starter", ProductImage = "image2" },
               new Product{ ProductID = 2, ProductName = "Biryani", ProductDescription = "Delicious Biryani", ProductCategory = "Mains", ProductImage = "image3" }
        };

        [HttpGet]
        [Route ("/products")]
        [ProducesResponseType (typeof (Product), 200)]
        [ProducesResponseType (400)]
        public IActionResult GetProducts()
        {
            if (products == null) {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet]
        [Route ("/id")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = products.Find(product => product.ProductID == id);
            if (product != null) { return Ok(product); }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if (product == null) { return BadRequest(); }
            products.Add(product);
            return Ok(products);
        }
    }
}
