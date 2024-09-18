using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.ProductAPI.Data.Dto;
using Shopping.ProductAPI.Model;
using Shopping.ProductAPI.Model.Context;

namespace Shopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductDto>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> FindById(long id)
        {
            Product products = await _context.Products.Where(p => p.Id == id)
                                                      .FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(products);
        }

        public async Task<ProductDto> Create(ProductDto product)
        {
            Product products = _mapper.Map<Product>(product);
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(products);
        }
        public async Task<ProductDto> Update(ProductDto product)
        {
            Product products = _mapper.Map<Product>(product);
            _context.Products.Update(products);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(products);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product products = await _context.Products.Where(p => p.Id == id)
                                                      .FirstOrDefaultAsync();
                if(products is Product)
                {
                    _context.Products.Remove(products);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
