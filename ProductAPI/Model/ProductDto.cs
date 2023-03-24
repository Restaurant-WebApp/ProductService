using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Model
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string ProductDescription { get; set; }
        public Category ProductCategory { get; set; }
        public string ProductImageUrl { get; set; }
    }
}
