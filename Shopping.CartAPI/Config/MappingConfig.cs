using AutoMapper;
using Shopping.CartAPI.Data.Dto;
using Shopping.CartAPI.Model;

namespace Shopping.CartApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        { 
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                config.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailDto, CartDetail>().ReverseMap();
                config.CreateMap<CartDto, Cart>().ReverseMap();

            });
            return mappingConfig;
        }  
    }
}
