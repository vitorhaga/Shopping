using AutoMapper;
using Shopping.ProductAPI.Data.Dto;
using Shopping.ProductAPI.Model;

namespace Shopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        { 
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }  
    }
}
