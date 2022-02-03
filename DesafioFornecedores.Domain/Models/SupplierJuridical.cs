using System;
using System.Collections.Generic;
using DesafioFornecedores.Domain.Tools;
using FluentValidation;

namespace DesafioFornecedores.Domain.Models
{
    public class SupplierJuridical : Supplier
    {

        public string CompanyName { get;private set; }
        public string Cnpj { get;private set; }
        public DateTime OpenDate { get;private set; }

        public SupplierJuridical()
        {
        }

        public SupplierJuridical(string companyName, string fantasyName, string cnpj,
                                bool active, Email email, Address address,List<Phone> phone)
                                : base(active,address, email, phone, fantasyName)
        {
            SetCompanyName(companyName);
            SetCnpj(cnpj);
            isValid();
        }


        public void SetCompanyName(string companyName){
            StringEmptyOrNull(companyName,"Company name");

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

        private void StringEmptyOrNull(string text,string message){
             if(string.IsNullOrEmpty(text))
             throw new DomainExceptions($"{message} cannot be empty");
        }

    public override bool isValid(){
            var result = new SupplierValidator().Validate(this);
            return result.IsValid;
        }
    }

    public class SupplierJuridicalValidator : AbstractValidator<SupplierJuridical>
    {
        public SupplierJuridicalValidator()
        {
            RuleFor(x => x.Cnpj)
                    .Length(14)
                    .WithMessage("the field needs to be 14 characters long")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Active is null");
              RuleFor(x => x.CompanyName)
                    .MaximumLength(256)
                    .WithMessage("the Company Name field for can have up to 256 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Name is null");

                RuleFor(x => x.OpenDate)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Name is null");
        }
    }
}