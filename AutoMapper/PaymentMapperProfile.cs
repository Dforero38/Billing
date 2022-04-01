using AutoMapper;
using Billing.Domain.Entity;
using Billing.DTOs;

namespace Billing.AutoMapper
{
    public class PaymentMapperProfile : Profile
    {
        public PaymentMapperProfile()
        {
            FromPaymentToPaymentDTO();
        }

        private void FromPaymentToPaymentDTO()
        {
            CreateMap<Payment, PaymentDTO>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(target => target.IdCustomer, opt => opt.MapFrom(source => source.IdCustomer))
                .ForMember(target => target.Date, opt => opt.MapFrom(source => source.Date))
                .ForMember(target => target.Value, opt => opt.MapFrom(source => source.Value))
                .ForMember(target => target.idBill, opt => opt.MapFrom(source => source.NumberPayment))
                .ForMember(target => target.TypePay, opt => opt.MapFrom(source => 2))
                .ReverseMap();
        }
    }
}
