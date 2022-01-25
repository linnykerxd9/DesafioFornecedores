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

        public Supplier(bool active,string email, string zipCode, string street, string numberAddress,
                        string neighborhood, string city, string state, string ddd, string numberPhone)
        {
            Active = active;
            SetAddress(new Address(zipCode,street,numberAddress,neighborhood,city,state,this.Id));
            SetEmail(new Email(email,this.Id));
            SetPhone(new Phone(ddd,numberPhone,this.Id));
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