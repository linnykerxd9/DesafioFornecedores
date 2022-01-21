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

        protected Address() { }
        
        public Address(string zipCode, string street, string number, string neighborhood, string city, string state)
        {
            SetZipCode(zipCode);
            SetStreet(street);
            SetNumber(number);
            SetNeighborhood(neighborhood);
            SetCity(city);
            SetState(state);
        }

        public void SetZipCode(string zipcode)
        {
            StringEmptyOrNull(zipcode,"Zip Code");
            SizeIsValid(zipcode.Length,8,"Zip code");
            ZipCode = zipcode;
        }
        public void SetStreet(string street)
        {
            StringEmptyOrNull(street,"Street");
            SizeIsValid(street.Length,4,200,"Street");

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
            SizeIsValid(neighborhood.Length,5,200,"Neighborhood");

            Neighborhood = neighborhood;
        }
        public void SetCity(string city){
            StringEmptyOrNull(city,"City");
            SizeIsValid(city.Length,2,100,"City");

            City = city;
        }
        public void SetState(string state){
            StringEmptyOrNull(state,"State");
            SizeIsValid(state.Length,10,100,"State");

            State = state;
        }


        private void StringEmptyOrNull(string text,string message){
             if(string.IsNullOrEmpty(text))
             throw new DomainExceptions($"{message} cannot be empty");
        }
        private void SizeIsValid(int value, int lengMin,string message){
            if(value != lengMin)
                throw new DomainExceptions($"the size of the {message} is incorrect");
        }
        private void SizeIsValid(int value, int lengMin, int lengMax,string message)
         {
                if(value < lengMin || value > lengMax)
                throw new DomainExceptions($"the {message} name can only be between {lengMin} to {lengMax} characters");
         }
    }
}