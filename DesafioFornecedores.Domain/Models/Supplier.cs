using System.Collections.Generic;
using DesafioFornecedores.Domain.Tools;
using DesafioFornecedores.Domain.Interface.Repository;

namespace DesafioFornecedores.Domain.Models
{
    public class Supplier : Entity, IAggregateRoot
    {
        public bool Active { get; private set; }
        public string FantasyName { get; private set; }
        
        public Email Email { get;private set; }
        public Address Address { get;private set; }
        private List<Phone> Phone { get; set; }
        public IReadOnlyCollection<Phone> Phones { get{ return Phone;} }

        public Supplier()
        {
        }

        public Supplier(bool active, Address address,Email email, Phone phone,string fantasyName)
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
            Email = email;
        }
        public void SetAddress(Address address){
            Address = address;
        }
        public void SetPhone(Phone phone){
            Phone.Add(phone);
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