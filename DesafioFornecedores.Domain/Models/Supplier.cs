using System.Collections.Generic;
using DesafioFornecedores.Domain.Interface;
using DesafioFornecedores.Domain.Interface.Repository;

namespace DesafioFornecedores.Domain.Models
{
    public class Supplier : Entity, IAggregateRoot
    {
        public bool Active { get; private set; }
        public Email Email { get;private set; }
        public Address Address { get;private set; }
        private List<Phone> Phone { get; set; }
        public IReadOnlyCollection<Phone> Phones { get{ return Phone;} }

        public Supplier(bool active,Email email, Address address, Phone phone)
        {
            Active = active;
            SetAddress(address);
            SetEmail(email);
            SetPhone(phone);
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
    }
}