using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Model;

namespace ProductAPI.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public ProductRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);

            // Check if an existing product with the same ID exists in the database
            Product existingProduct = await _context.Products.FindAsync(product.ProductId);

            if (existingProduct != null)
            {
                // Update the existing product with the new values
                _mapper.Map(productDto, existingProduct);
            }
            else
            {
                // Add the new product to the database
                _context.Products.Add(product);
            }

            try
            {
                // Save the changes to the database
                await _context.SaveChangesAsync();
                return _mapper.Map<Product, ProductDto>(product);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // A concurrency conflict occurred
                // Handle this situation accordingly (e.g., retry the operation, inform the user, implement custom resolution)
            }

            throw new InvalidOperationException();
        }



        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if(product == null)
                {
                    return false;
                }
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;

            }
            catch(Exception ex) 
            { 
                return false;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            IEnumerable <Product> productList = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(productList);

        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _context.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
