using AutoMapper;
using CDCNfinal.API.Data.DTOs;
using CDCNfinal.API.Data.Entities;

namespace CDCNfinal.API.Mapping
{
    public class AutoMappingConfiguration : Profile
    {
        public AutoMappingConfiguration()
        {
            CreateMap<Product, ProductDTO>();

            CreateMap<ProductDTO, Product>();

            CreateMap<Product, ProductDetailDTO>();

            CreateMap<ProductAddDTO, Product>();
        }
    }
}