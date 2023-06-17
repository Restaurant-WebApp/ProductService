using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using ProductAPI.Model;
using ProductAPI.Controllers;
using ProductAPI.Repository;


namespace ProductAPI.Tests
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductRepo> _mockProductRepo;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockProductRepo = new Mock<IProductRepo>();
            _controller = new ProductController(_mockProductRepo.Object);
        }

        [Fact]
        public async Task GetProducts_ReturnsListOfProducts()
        {
            // Arrange
            var expectedProducts = new List<ProductDto>
        {
            new ProductDto { ProductId = 1, ProductName = "Product 1" },
            new ProductDto { ProductId = 2, ProductName = "Product 2" },
            new ProductDto { ProductId = 3, ProductName = "Product 3" }
        };

            _mockProductRepo.Setup(repo => repo.GetProducts())
                            .ReturnsAsync(expectedProducts);

            // Act
            var result = await _controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ResponseDto>(okResult.Value);
            var products = Assert.IsAssignableFrom<IEnumerable<ProductDto>>(response.Result);
            Assert.Equal(expectedProducts.Count, products.Count());
        }

        [Fact]
        public async Task GetProductById_ReturnsProduct()
        {
            // Arrange
            var expectedProduct = new ProductDto { ProductId = 1, ProductName = "Product 1" };

            _mockProductRepo.Setup(repo => repo.GetProductById(It.IsAny<int>()))
                            .ReturnsAsync(expectedProduct);

            // Act
            var result = await _controller.GetProductById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ResponseDto>(okResult.Value);
            var product = Assert.IsType<ProductDto>(response.Result);
            Assert.Equal(expectedProduct.ProductId, product.ProductId);
            Assert.Equal(expectedProduct.ProductName, product.ProductName);
        }

        [Fact]
        public async Task Post_And_Put_ReturnsResponseWithUpdatedProducts()
        {
            // Arrange
            var productDto = new ProductDto { ProductId = 1, ProductName = "New Product" };
            var updatedProductDto = new ProductDto { ProductId = 1, ProductName = "Updated Product" };

            // Setup mock repository
            _mockProductRepo.Setup(repo => repo.CreateUpdateProduct(productDto))
                            .ReturnsAsync(updatedProductDto);

            _mockProductRepo.Setup(repo => repo.GetProducts())
                            .ReturnsAsync(new List<ProductDto> { updatedProductDto });

            // Act
            var postResult = await _controller.Post(productDto);
            var putResult = await _controller.Put(productDto);

            // Assert
            // Post
            var postOkResult = Assert.IsType<OkObjectResult>(postResult);
            var postResponse = Assert.IsType<ResponseDto>(postOkResult.Value);
            var postProductList = Assert.IsType<List<ProductDto>>(postResponse.Result);
            Assert.Contains(updatedProductDto, postProductList);

            // Put
            var putOkResult = Assert.IsType<OkObjectResult>(putResult);
            var putResponse = Assert.IsType<ResponseDto>(putOkResult.Value);
            var putProductList = Assert.IsType<List<ProductDto>>(putResponse.Result);
            Assert.Contains(updatedProductDto, putProductList);
        }


        [Fact]
        public async Task Delete_ReturnsSuccessStatus()
        {
            // Arrange
            var productId = 1;
            var isSuccess = true;
            _mockProductRepo.Setup(repo => repo.DeleteProduct(It.IsAny<int>()))
                            .ReturnsAsync(isSuccess);

            // Act
            var result = await _controller.Delete(productId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ResponseDto>(okResult.Value);
            var deletionStatus = Assert.IsType<bool>(response.Result);
            Assert.Equal(isSuccess, deletionStatus);
        }
    }
}

