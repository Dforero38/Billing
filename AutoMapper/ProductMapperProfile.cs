using AutoMapper;
using Billing.Domain.Entity;
using Billing.DTOs;

namespace Billing.AutoMapper
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            FromProductToProductDTO();
            FromProductDTOToProduct();
            FromMarkDTOToMark();
        }

        private void FromProductToProductDTO()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(target => target.Description, opt => opt.MapFrom(source => source.Description))
                .ForMember(target => target.Price, opt => opt.MapFrom(source => source.Price))
                .ForMember(target => target.IdMark, opt => opt.MapFrom(source => source.IdMark))
                .ForMember(target => target.NameMark, opt => opt.MapFrom(source => source.IdMarkNavigation.Description));
        }

        private void FromProductDTOToProduct()
        {
            CreateMap<ProductDTO, Product>()
              .ForMember(target => target.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(target => target.Description, opt => opt.MapFrom(source => source.Description))
              .ForMember(target => target.Price, opt => opt.MapFrom(source => source.Price))
              .ForMember(target => target.IdMark, opt => opt.MapFrom(source => source.IdMark));
        }

        private void FromMarkDTOToMark()
        {
            CreateMap<MarkDTO, Mark>()
              .ForMember(target => target.Id, opt => opt.MapFrom(source => source.Id))
              .ForMember(target => target.Description, opt => opt.MapFrom(source => source.Description))
              .ReverseMap();
        }

    }

}
