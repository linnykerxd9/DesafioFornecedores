using System;
using DesafioFornecedores.Domain.Tools;

namespace DesafioFornecedores.Domain.Models
{
    public class Address : Entity
    {
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string Reference { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public Guid SupplierId { get; private set; }
        protected Address() { }
        
        public Address(string zipCode, string street, string number, string neighborhood, string city, string state, Guid supplierId)
        {
            SetZipCode(zipCode);
            SetStreet(street);
            SetNumber(number);
            SetNeighborhood(neighborhood);
            SetCity(city);
            SetState(state);
            SetSupplierId(supplierId);
        }

        public void SetZipCode(string zipcode)
        {
            StringEmptyOrNull(zipcode,"Zip Code");
            ZipCode = zipcode;
        }
        public void SetStreet(string street)
        {
            StringEmptyOrNull(street,"Street");

            Street = street;
        }
        public void SetNumber(string number){
            StringEmptyOrNull(number,"Number");
            Number = number;
        }
        public void SetComplement(string complement){
            StringEmptyOrNull(complement,"Complement");
            
            Complement = complement;
        }
        public void SetReference(string reference){
            StringEmptyOrNull(reference,"Reference");

            Reference = reference;
        }
        public void SetNeighborhood(string neighborhood){
            StringEmptyOrNull(neighborhood,"Neighborhood");

            Neighborhood = neighborhood;
        }
        public void SetCity(string city){
            StringEmptyOrNull(city,"City");

            City = city;
        }
        public void SetState(string state){
            StringEmptyOrNull(state,"State");

            State = state;
        }
         public void SetSupplierId(Guid id){
            if(string.IsNullOrEmpty(id.ToString())) throw new DomainExceptions("Id is null or empty");

            SupplierId = id;
        }

        private void StringEmptyOrNull(string text,string message){
             if(string.IsNullOrEmpty(text))
             throw new DomainExceptions($"{message} cannot be empty");
        }
    }
}