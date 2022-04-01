using AutoMapper;
using Billing.Domain.Entity;
using Billing.DTOs;

namespace Billing.AutoMapper
{
    public class MovementProductMapperProfile : Profile
    { 
        public MovementProductMapperProfile()
        {
            FromMovementProductToMovementProductDTO();
            
        }

        private void FromMovementProductToMovementProductDTO()
        {
            CreateMap<MovementProduct, MovementProductDTO>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(target => target.IdMovementBill, opt => opt.MapFrom(source => source.IdMovementBill))
                .ForMember(target => target.IdProduct, opt => opt.MapFrom(source => source.IdProduct))
                .ForMember(target => target.Date, opt => opt.MapFrom(source => source.Date))
                .ForMember(target => target.Quantity, opt => opt.MapFrom(source => source.Quantity))
                .ForMember(target => target.UnitValue, opt => opt.MapFrom(source => source.UnitValue))
                .ForMember(target => target.TotalValue, opt => opt.MapFrom(source => source.TotalValue))
                .ReverseMap();
        }
    }
}
