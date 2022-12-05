using AutoMapper;
using CDCNfinal.API.Data.DTOs;
using CDCNfinal.API.Data.Entities;

namespace CDCFinal.API.Mapping
{
    public class AutoMappingConfiguration : Profile
    {
        public AutoMappingConfiguration()
        {
            CreateMap<Product, ProductDTO>();

            CreateMap<ProductDTO, Product>();

            CreateMap<Product, ProductDetailDTO>();

            CreateMap<ProductAddDTO, Product>();

            CreateMap<OrderDTO, Order>();

            CreateMap<Order, OrderOverviewDto>()
                .ForMember(
                    dest => dest.Product,
                    otp => otp.MapFrom(src => src.Product)
                )
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => ((Status.StatusEnum)src.StatusOrder).ToString())
                );
        }
    }
}