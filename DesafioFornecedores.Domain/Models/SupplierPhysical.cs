using System;
using System.Collections.Generic;
using DesafioFornecedores.Domain.Tools;
using FluentValidation;

namespace DesafioFornecedores.Domain.Models
{
    public class SupplierPhysical : Supplier
    {
        public string FullName { get; private set; }
        public string Cpf { get; private set; }
        public DateTime BirthDate  { get;private  set; }

        public SupplierPhysical()
        {
        }

        public SupplierPhysical(string fantasyName, string fullName, string cpf, DateTime birthDate,
                               bool active, Email email, Address address,List<Phone> phone)
                                : base(active,address,email, phone,fantasyName)
        {
            SetFullName(fullName);
            SetCpf(cpf);
            SetBirthDate(birthDate);
            isValid();
        }

        public void SetFullName(string fullName){
            StringEmptyOrNull(fullName,"Full name");

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


            BirthDate = date;
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

    public class SupplierPhysicalValidator : AbstractValidator<SupplierPhysical>
    {
        public SupplierPhysicalValidator()
        {
            RuleFor(x => x.Cpf)
                    .Length(11)
                    .WithMessage("the field needs to be 11 characters long")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Cpf is null");
              RuleFor(x => x.FullName)
                    .MaximumLength(256)
                    .WithMessage("the Full Name field for can have up to 256 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Name is null");
                RuleFor(x => x.BirthDate)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("BirthDate is null");
        }
    }
}