using System;
using DesafioFornecedores.Domain.Tools;

namespace DesafioFornecedores.Domain.Models
{
    public class SupplierPhysical : Supplier
    {
        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate  { get;private  set; }
        public Guid SupplierId {get; private set;}


        public SupplierPhysical(string fantasyName, string fullName, string cpf, DateTime birthDate,Guid supplierId,
                               bool active, Email email, Address address,Phone phone)
                                : base(active, email, address, phone,fantasyName)
        {
            SetFullName(fullName);
            SetCpf(cpf);
            SetBirthDate(birthDate);
            SetSupplierId(supplierId);
        }

        public void SetFullName(string fullName){
            StringEmptyOrNull(fullName,"Full name");
            SizeIsValid(fullName.Length,2,250,"Full");

            FullName = fullName;
        }
      
        public void SetCpf(string cpf){
            if(!cpf.IsCpf())
                throw new DomainExceptions("Cpf is invalid");

            Cpf = cpf;
        }
        public void SetBirthDate(DateTime date){
            if(DateTime.Now < date)
                throw new DomainExceptions("Date invalid");
            if(!date.IsOlderAge())
                throw new DomainExceptions("you need to be of age");

            BirthDate = date;
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

          public void SetSupplierId(Guid id){
            StringEmptyOrNull(id.ToString(),"Supplier Id");
            
            SupplierId = id;
        }
    }
}