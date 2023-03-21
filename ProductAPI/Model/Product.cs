namespace ProductAPI.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public string ProductImage { get; set; }

        public Product() { }    

        public Product(int productID, string productName, string productDescription, string productCategory, string productImage)
        {
            ProductID = productID;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductCategory = productCategory;
            ProductImage = productImage;
        }
    }
}
