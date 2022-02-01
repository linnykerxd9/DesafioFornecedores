using System.Collections.Generic;
using AutoMapper;
using DesafioFornecedores.Domain.Models;
using DesafioFornecedores.WebApp.Models;

namespace DesafioFornecedores.WebApp.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateOrEditSupplierViewModel, SupplierJuridical>().ReverseMap();
            CreateMap<CreateOrEditSupplierViewModel, SupplierPhysical>().ReverseMap();
            CreateMap<SupplierPhysical, SupplierListViewModel>();
            CreateMap<SupplierJuridical, SupplierListViewModel>();

            
            CreateMap<AddressViewModel, Address>().ReverseMap();
            CreateMap<EmailViewModel, Email>().ReverseMap();
            CreateMap<InsertPhoneViewModel,Phone>().ReverseMap();
            CreateMap<PhoneViewModel, Phone>().ReverseMap();
            CreateMap<AddressUpdateViewModel, Address>().ReverseMap();
            CreateMap<EmailUpdateViewModel, Email>().ReverseMap();
            CreateMap<UpdateOrDeletePhoneViewModel, Phone>().ReverseMap();

        }
    }
}