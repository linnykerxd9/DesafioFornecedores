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
            CreateMap<EditSupplierViewModel, SupplierJuridical>().ReverseMap();
            CreateMap<EditSupplierViewModel, SupplierPhysical>().ReverseMap();
            CreateMap<CreateSupplierViewModel, SupplierPhysical>().ReverseMap();
            CreateMap<CreateSupplierViewModel, SupplierJuridical>().ReverseMap();
            CreateMap<DeleteSupplierViewModel,Supplier>().ReverseMap();
            CreateMap<SupplierPhysical, SupplierListViewModel>();
            CreateMap<SupplierJuridical, SupplierListViewModel>();
            
            CreateMap<InsertPhoneViewModel,Phone>().ReverseMap();
            CreateMap<PhoneViewModel, Phone>().ReverseMap();
            CreateMap<DeletePhoneViewModel, Phone>().ReverseMap();
            CreateMap<UpdatePhoneViewModel, Phone>().ReverseMap();
            CreateMap<AddressUpdateViewModel, Address>().ReverseMap();
            CreateMap<AddressViewModel, Address>().ReverseMap();
            CreateMap<EmailUpdateViewModel, Email>().ReverseMap();
            CreateMap<EmailViewModel, Email>().ReverseMap();

            CreateMap<Category, CategoryViewModel>();

        }
    }
}