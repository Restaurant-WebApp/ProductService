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
        [Route("/products")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepo.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductById(int id)
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
            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto newProduct = await _productRepo.CreateUpdateProduct(productDto);
                _response.Result = newProduct;

                // Retrieve all products after creating a new product
                IEnumerable<ProductDto> productDtos = await _productRepo.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto newProduct = await _productRepo.CreateUpdateProduct(productDto);
                _response.Result = newProduct;

                // Retrieve all products after updating a product
                IEnumerable<ProductDto> productDtos = await _productRepo.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
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
            return Ok(_response);
        }


    }
}
