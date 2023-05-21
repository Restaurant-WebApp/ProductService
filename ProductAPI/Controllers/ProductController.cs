using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ProductAPI.Model;
using ProductAPI.Repository;
using System.Formats.Asn1;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ResponseDto _response;
        private readonly IProductRepo _productRepo;

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

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetProductById(int id)
        {
            try
            {
                ProductDto productDto = await _productRepo.GetProductById(id);
                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto newProduct = await _productRepo.CreateUpdateProduct(productDto);
                _response.Result = newProduct;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto newProduct = await _productRepo.CreateUpdateProduct(productDto);
                _response.Result = newProduct;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _productRepo.DeleteProduct(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
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
