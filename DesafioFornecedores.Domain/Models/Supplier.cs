using System.Collections.Generic;
using DesafioFornecedores.Domain.Tools;
using DesafioFornecedores.Domain.Interface.Repository;
using System;

namespace DesafioFornecedores.Domain.Models
{
    public class Supplier : Entity, IAggregateRoot
    {
        public bool Active { get; private set; }
        public string FantasyName { get; private set; }
        
        public Email Email { get;private set; }
        public Address Address { get;private set; }
         public ICollection<Phone> Phone { get;private set; } = new List<Phone>();

        public Supplier()
        {
        }

        public Supplier(bool active, Address address,Email email,List<Phone> phone,string fantasyName)
        {
            Active = active;
            SetAddress(address);
            SetEmail(email);
            SetPhone(phone);
            SetFantasyName(fantasyName);
        }
        protected void Activate() {
            Active = true;
        }
        protected void Disable() {
            Active = false;
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
                  if(string.IsNullOrEmpty(item.Ddd) || item.Ddd.Length < 2 || item.Ddd.Length > 3)
                    throw new DomainExceptions("DDD is invalid");
                 if(string.IsNullOrEmpty(item.Number) || item.Number.Length > 9 ||  item.Number.Length < 8)
                    throw new DomainExceptions("Number is invalid");
            }
            Phone = phone;
        }
          public void SetFantasyName(string fantasyName){
            if(string.IsNullOrEmpty(fantasyName)) 
            throw new DomainExceptions($"Fantasy name cannot be empty");

            if(fantasyName.Length < 2 || fantasyName.Length > 100)
             throw new DomainExceptions($"the Fantasy name can only be between 2 to 100 characters");

            FantasyName = fantasyName;
        }
    }
}