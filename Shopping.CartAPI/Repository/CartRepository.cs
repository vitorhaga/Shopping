using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopping.CartAPI.Data.Dto;
using Shopping.CartAPI.Model;
using Shopping.CartAPI.Model.Context;

namespace Shopping.CartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public CartRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(string userId)
        {
            var cartHeader = await _context.CartHeaders
                        .FirstOrDefaultAsync(c => c.UserId == userId);
            if (cartHeader != null) 
            {
                _context.CartDetails
                    .RemoveRange(
                    _context.CartDetails.Where(c => c.CartHeaderId == cartHeader!.Id));
                _context.CartHeaders.Remove(cartHeader!);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CartDto> FindCartByUserId(string userId)
        {
            Cart cart = new()
            {
                CartHeader = await _context.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId),
            };
            cart.CartDetails = _context.CartDetails
                                        .Where(c => c.CartHeaderId == cart.CartHeader.Id)
                                        .Include(c => c.Product);

            return _mapper.Map<CartDto>(cart);
        }

        public Task<CartDto> GetCartByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(long cartDetailsId)
        {
            try
            {
                CartDetail? cartDetail = await _context.CartDetails
                    .FirstOrDefaultAsync(c => c.Id == cartDetailsId);

                int total = _context.CartDetails
                    .Where(c => c.CartHeaderId == cartDetail!.CartHeaderId).Count();

                _context.CartDetails.Remove(cartDetail!);

                if(total == 1)
                {
                    var cartHeaderToRemove = await _context.CartHeaders
                        .FirstOrDefaultAsync(c => c.Id == cartDetail!.CartHeaderId);
                    _context.CartHeaders.Remove(cartHeaderToRemove!);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CartDto> SaveOrUpdareCart(CartDto cartDto)
        {
            Cart cart = _mapper.Map<Cart>(cartDto);

            var product = await _context.Products.FirstOrDefaultAsync(
                p => p.Id == cartDto.CartDetails.FirstOrDefault().ProductId);

            if (product is Product) 
            { 
                _context.Products.Add(cart.CartDetails.FirstOrDefault().Product);
                await _context.SaveChangesAsync();
            }

            var cartHeader = await _context.CartHeaders.AsNoTracking()
                .FirstOrDefaultAsync(c => c.UserId == cart.CartHeader.UserId);

            if (cartHeader is CartHeader)
            {
                _context.CartHeaders.Add(cart.CartHeader);
                await _context.SaveChangesAsync();
                cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.Id;
                cart.CartDetails.FirstOrDefault().Product = null;
                _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
            }
            else
            {
                var cartDetail = await _context.CartDetails.AsNoTracking()
                    .FirstOrDefaultAsync(
                    p => p.ProductId == cartDto.CartDetails.FirstOrDefault().ProductId && 
                    p.CartHeaderId == cartHeader.Id); 

                if (cartHeader is CartHeader)
                {
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartHeader.Id;
                    cart.CartDetails.FirstOrDefault().Product = null;
                    _context.CartDetails.Add(cart.CartDetails.FirstOrDefault());
                }
                else
                {
                    cart.CartDetails.FirstOrDefault().Product = null;
                    cart.CartDetails.FirstOrDefault().Count += cartDetail.Count;
                    cart.CartDetails.FirstOrDefault().Id = cartDetail.Id;
                    cart.CartDetails.FirstOrDefault().CartHeaderId = cartDetail.CartHeaderId;
                    _context.CartDetails.Update(cart.CartDetails.FirstOrDefault());
                }
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<CartDto>(cart);
        }
    }
}
