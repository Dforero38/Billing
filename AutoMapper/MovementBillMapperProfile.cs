using AutoMapper;
using Billing.Domain.Entity;
using Billing.DTOs;

namespace Billing.AutoMapper
{
    public class MovementBillMapperProfile: Profile
    {
        public MovementBillMapperProfile()
        {
            FromMovementBillToMovementBillDTO();
            FromMovementBillToCreateBillDTO();
            FromMovementBillToBillingForPayDTO();
        }
        private void FromMovementBillToMovementBillDTO()
        {
            CreateMap<MovementBill, MovementBillDTO>()
                .ForMember(tarjet => tarjet.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(tarjet => tarjet.IdCustomer, opt => opt.MapFrom(source => source.IdCustomer))
                .ForMember(tarjet => tarjet.IdTransactionType, opt => opt.MapFrom(source => source.IdTransactionType))
                .ForMember(tarjet => tarjet.Date, opt => opt.MapFrom(source => source.Date))
                .ForMember(tarjet => tarjet.Total, opt => opt.MapFrom(source => source.Total))
                .ForMember(tarjet => tarjet.SubTotal, opt => opt.MapFrom(source => source.SubTotal))
                .ForMember(tarjet => tarjet.Iva, opt => opt.MapFrom(source => source.Iva))
                .ForMember(tarjet => tarjet.BusinessName, opt => opt.MapFrom(source => source.IdCustomerNavigation.BusinessName))
                .ForMember(tarjet => tarjet.Nit, opt => opt.MapFrom(source => source.IdCustomerNavigation.Nit))
                .ForMember(tarjet => tarjet.Address, opt => opt.MapFrom(source => source.IdCustomerNavigation.Address))
                .ForMember(tarjet => tarjet.Phone, opt => opt.MapFrom(source => source.IdCustomerNavigation.Phone))
                .ForMember(tarjet => tarjet.State, opt => opt.MapFrom(source => source.IdCustomerNavigation.State))
                .ForMember(tarjet => tarjet.RegistrationDate, opt => opt.MapFrom(source => source.IdCustomerNavigation.RegistrationDate))
                .ReverseMap();
        }

        private void FromMovementBillToCreateBillDTO()
        {
            CreateMap<MovementBill, CreateBillDTO>()
                .ForMember(tarjet => tarjet.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(tarjet => tarjet.IdCustomer, opt => opt.MapFrom(source => source.IdCustomer))
                .ForMember(tarjet => tarjet.IdTransactionType, opt => opt.MapFrom(source => source.IdTransactionType))
                .ForMember(tarjet => tarjet.Date, opt => opt.MapFrom(source => source.Date))
                .ForMember(tarjet => tarjet.Total, opt => opt.MapFrom(source => source.Total))
                .ForMember(tarjet => tarjet.SubTotal, opt => opt.MapFrom(source => source.SubTotal))
                .ForMember(tarjet => tarjet.Iva, opt => opt.MapFrom(source => source.Iva))
                .ReverseMap();
        }
        private void FromMovementBillToBillingForPayDTO()
        {
            CreateMap<MovementBill, BillingForPayDTO>()
                .ForMember(tarjet => tarjet.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(tarjet => tarjet.LargeDescription, opt => opt.MapFrom(source => "NumDian: " + source.NumberBill + " - Cliente: " + source.IdCustomerNavigation.BusinessName + " - Valor: " + source.Total.ToString("0.##") ))
                .ReverseMap();
        }

    }
}
