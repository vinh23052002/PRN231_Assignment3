using API.Models;
using AutoMapper;

namespace API.DTO
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
