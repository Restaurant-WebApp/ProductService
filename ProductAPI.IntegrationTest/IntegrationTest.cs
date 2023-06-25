using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;
using ProductAPI.Model;

namespace ProductAPI.IntegrationTest
{
    public class ProductControllerIntegrationTests : IDisposable
    {
        private readonly HttpClient _client;
        public ProductControllerIntegrationTests()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:7278") // API base address
            };
        }
        public void Dispose()
        {
            _client.Dispose();
        }
        [Fact]
        public async Task Post_ShouldCreateNewProduct()
        {
            // Arrange
            var productDto = new ProductDto
            {
                ProductId = 11,
                ProductName = "Test",
                ProductDescription = "Test",
                ProductImageUrl = "Test Url",
                Price = 100,
                ProductCategory = 0
            };
            var content = new StringContent(JsonConvert.SerializeObject(productDto), Encoding.UTF8, "application/json");
            // Act
            try
            {
                var response = await _client.PostAsync("/api/products", content);
                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResponseDto>(responseBody);
                // Assert the response structure
                Assert.True(result.IsSuccess);
                Assert.Null(result.ErrorMessages);
                Assert.NotNull(result.Result);
                // Assert the created product
                var createdProduct = JsonConvert.DeserializeObject<ProductDto>(result.Result.ToString());
                Assert.Equal("Test", createdProduct.ProductName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
