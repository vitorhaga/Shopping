using Microsoft.AspNetCore.Mvc;
using Shopping.CartAPI.Data.Dto;
using Shopping.CartAPI.Repository;

namespace Shopping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _repository;
        public CartController(ICartRepository cartRepository)
        {
            _repository = cartRepository;
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartDto>> FindById(string id) 
        {
            var cart = await _repository.FindCartByUserId(id);
            if (cart is not CartDto) 
                return NotFound();
            return Ok(cart);
        } 
        
        [HttpPost("add-cart")]
        public async Task<ActionResult<CartDto>> AddCart(CartDto data) 
        {
            var cart = await _repository.SaveOrUpdateCart(data);
            if (cart is not CartDto) 
                return NotFound();
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartDto>> UpdateCart(CartDto data)
        {
            var cart = await _repository.SaveOrUpdateCart(data);
            if (cart is not CartDto)
                return NotFound();
            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartDto>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status)
                return BadRequest();
            return Ok(status);
        }
    }
}
