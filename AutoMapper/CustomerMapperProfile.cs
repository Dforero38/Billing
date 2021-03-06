using AutoMapper;
using Billing.Domain.Entity;
using Billing.DTOs;

namespace Billing.AutoMapper
{
    public class CustomerMapperProfile: Profile
    {
        public CustomerMapperProfile()
        {
            FromCustomerToCustomerDTO();
            FromTypeCustomerToTypeCustomerDTO();
            FromCustomerDTOToCustomer();

        }
        private void FromCustomerToCustomerDTO()
        {
            CreateMap   <Customer, CustomerDTO>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(target => target.BusinessName, opt => opt.MapFrom(source => source.BusinessName))
                .ForMember(target => target.Nit, opt => opt.MapFrom(source => source.Nit))
                .ForMember(target => target.IdTypeCustomer, opt => opt.MapFrom(source => source.IdTypeCustomer))
                .ForMember(target => target.DescriptionTypeCustomer, opt => opt.MapFrom(source => source.IdTypeCustomerNavigation.Description))
                .ForMember(target => target.Address, opt => opt.MapFrom(source => source.Address))
                .ForMember(target => target.Phone, opt => opt.MapFrom(source => source.Phone))
                .ForMember(target => target.State, opt => opt.MapFrom(source => source.State))
                .ForMember(target => target.RegistrationDate, opt => opt.MapFrom(source => source.RegistrationDate));
        }

        private void FromCustomerDTOToCustomer()
        {
            CreateMap<CustomerDTO, Customer>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(target => target.BusinessName, opt => opt.MapFrom(source => source.BusinessName))
                .ForMember(target => target.Nit, opt => opt.MapFrom(source => source.Nit))
                .ForMember(target => target.IdTypeCustomer, opt => opt.MapFrom(source => source.IdTypeCustomer))
                .ForMember(target => target.Address, opt => opt.MapFrom(source => source.Address))
                .ForMember(target => target.Phone, opt => opt.MapFrom(source => source.Phone))
                .ForMember(target => target.State, opt => opt.MapFrom(source => source.State))
                .ForMember(target => target.RegistrationDate, opt => opt.MapFrom(source => source.RegistrationDate));
        }

        private void FromTypeCustomerToTypeCustomerDTO()
        {
            CreateMap<TypeCustomer, TypeCustomerDTO>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(target => target.Description, opt => opt.MapFrom(source => source.Description))
                .ReverseMap();
        }
    }
}
