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
            Product product = _mapper.Map<ProductDto,Product>(productDto);
            if (product.ProductId > 0)
            {
                _context.Products.Update(product);
            }
            else
            {
                _context.Products.Add(product); 
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Product, ProductDto>(product);

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

        public async Task<ProductDto> ProductById(int productId)
        {
            Product product = await _context.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
