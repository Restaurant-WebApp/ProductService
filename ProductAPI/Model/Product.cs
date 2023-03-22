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
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public string ProductImageUrl { get; set; }

        public Product() { }    

        public Product(int productID, string productName, string productDescription, string productCategory, string productImage)
        {
            ProductId = productID;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductCategory = productCategory;
            ProductImageUrl = productImage;
        }
    }
}
