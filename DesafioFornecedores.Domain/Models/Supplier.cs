using System.Collections.Generic;
using DesafioFornecedores.Domain.Tools;
using DesafioFornecedores.Domain.Interface.Repository;
using System;
using FluentValidation;

namespace DesafioFornecedores.Domain.Models
{
    public class Supplier : Entity, IAggregateRoot
    {
        public bool Active { get; private set; }
        public string FantasyName { get; private set; }
        
        public Email Email { get;private set; }
        public Address Address { get;private set; }
        public ICollection<Phone> Phone { get;private set; } = new List<Phone>();
        public ICollection<Product> Product {get; set;} = new List<Product>();

        public Supplier()
        {
        }

        public Supplier(bool active, Address address,Email email,List<Phone> phone,string fantasyName)
        {
            SetActive(active);
            SetAddress(address);
            SetEmail(email);
            SetPhone(phone);
            SetFantasyName(fantasyName);
            isValid();
        }
        public void SetActive(bool status) {
            Active = status;
        }
        public void SetEmail(Email email){
            email.SetSupplierId(Id);
            Email = email;
        }
        public void SetAddress(Address address){
            address.SetSupplierId(Id);
            Address = address;
        }
        public void SetPhone(ICollection<Phone> phone){
            foreach (var item in phone)
            {
                item.SetSupplierId(this.Id);
                  if(string.IsNullOrEmpty(item.Ddd))
                    throw new DomainExceptions("DDD is invalid");
                 if(string.IsNullOrEmpty(item.Number))
                    throw new DomainExceptions("Number is invalid");
            }
            Phone = phone;
        }
          public void SetFantasyName(string fantasyName){
            if(string.IsNullOrEmpty(fantasyName)) 
            throw new DomainExceptions($"Fantasy name cannot be empty");

            FantasyName = fantasyName;
        }
    public override bool isValid(){
            var result = new SupplierValidator().Validate(this);
            return result.IsValid;
        }
    }

    public class SupplierValidator : AbstractValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(x => x.Active)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Active is null");
              RuleFor(x => x.FantasyName)
                    .MaximumLength(256)
                    .WithMessage("the Fantasy Name field for can have up to 256 characters").NotEmpty()
                    .NotNull()
                    .WithMessage("Fantasy Name is null");
        }
    }
}