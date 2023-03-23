using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProductAPI.Model;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ResponseDto _response;
        private IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
            this._response = new ResponseDto();
        }
        

        [HttpGet]
        [Route ("/products")]
        public async Task<object> GetProducts()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepo.GetProducts();
                _response.Result = productDtos;
            }catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString()};
            }
            return _response;
        }

        /*[HttpGet]
        [Route ("/id")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = products.Find(product => product.ProductId == id);
            if (product != null) { return Ok(product); }
            return BadRequest();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            if (product == null) { return BadRequest(); }
            products.Add(product);
            return Ok(products);
        }*/
    }
}
