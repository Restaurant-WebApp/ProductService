using ProductAPI.Model;
using System.Collections.Generic;

namespace ProductAPI.Repository
{
    public interface IProductRepo
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);

        /*bool SaveChanges();
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void CreateProduct (Product product);*/

    }
}
