using System;

namespace DesafioFornecedores.WebApp.Models
{
    public class AddressViewModel
    {
        public string ZipCode { get;  set; }
        public string Street { get;  set; }
        public string Number { get;  set; }
        public string Complement { get;  set; }
        public string Reference { get;  set; }
        public string Neighborhood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
    }
    public class AddressUpdateViewModel
    {
        public Guid Id { get; set; }
        public string ZipCode { get;  set; }
        public string Street { get;  set; }
        public string Number { get;  set; }
        public string Complement { get;  set; }
        public string Reference { get;  set; }
        public string Neighborhood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
    }
}