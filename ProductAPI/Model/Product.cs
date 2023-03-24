using System.ComponentModel.DataAnnotations;

namespace ProductAPI.Model
{
    public class Product
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string ProductDescription { get; set; }
        public Category ProductCategory { get; set; }
        public string ProductImageUrl { get; set; }

        public Product() { }    

        public Product(int productID, string productName,int price, string productDescription, Category productCategory, string productImage)
        {
            ProductId = productID;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductCategory = productCategory;
            ProductImageUrl = productImage;
            Price = price;
        }
    }
}
