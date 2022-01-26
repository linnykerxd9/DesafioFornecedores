using System;
using DesafioFornecedores.Domain.Tools;

namespace DesafioFornecedores.Domain.Models
{
    public class SupplierJuridical : Supplier
    {

        public string CompanyName { get;private set; }
        public string Cnpj { get;private set; }
        public Guid SupplierId {get; private set;}
        public DateTime OpenDate { get;private set; }

        public SupplierJuridical(string companyName, string fantasyName, string cnpj, Guid supplierId,
                                bool active, Email email, Address address,Phone phone)
                                : base(active, email, address, phone, fantasyName)
        {
            SetSupplierId(supplierId);
            SetCompanyName(companyName);
            SetCnpj(cnpj);
        }


        public void SetCompanyName(string companyName){
            StringEmptyOrNull(companyName,"Company name");
            SizeIsValid(companyName.Length,2,250,"Company");

            CompanyName = companyName;
        }

        public void SetCnpj(string cnpj){
            if(!cnpj.IsCnpj())
                throw new DomainExceptions("Cnpj is invalid");
            
            Cnpj = cnpj;
        }
        public void SetOpenDate(DateTime date){
            if(DateTime.Now < date)
                throw new DomainExceptions("Date invalid");

            OpenDate = date;
        }
        public void SetSupplierId(Guid id){
            StringEmptyOrNull(id.ToString(),"Supplier Id");

            SupplierId = id;
        }

        private void StringEmptyOrNull(string text,string message){
             if(string.IsNullOrEmpty(text))
             throw new DomainExceptions($"{message} cannot be empty");
        }
        private void SizeIsValid(int value, int lengMin, int lengMax,string message)
         {
                if(value < lengMin || value> lengMax)
                throw new DomainExceptions($"the {message} name can only be between {lengMin} to {lengMax} characters");
         }
    }
}