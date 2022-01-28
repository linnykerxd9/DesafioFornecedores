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
            CreateMap<AddressViewModel,Address>().ReverseMap();
            CreateMap<CategoryViewModel,Category>().ReverseMap();
            CreateMap<EmailViewModel,Email>().ReverseMap();
            CreateMap<PhoneViewModel,Phone>().ReverseMap();
            CreateMap<IEnumerable<PhoneViewModel>,IEnumerable<Phone>>().ReverseMap();
            CreateMap<ProductViewModel,Product>().ReverseMap();
            CreateMap<SupplierViewModel,Supplier>().ReverseMap();
            CreateMap<SupplierViewModel,SupplierJuridical>().ReverseMap();
            CreateMap<SupplierViewModel,SupplierPhysical>().ReverseMap();
        }
    }
}