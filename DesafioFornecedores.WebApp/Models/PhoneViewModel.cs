using System;

namespace DesafioFornecedores.WebApp.Models
{
    public class PhoneViewModel
    {
        public string Ddd { get;  set; }
        public string Number { get;  set; }
    }
    public class UpdateOrDeletePhoneViewModel
    {
        public Guid Id { get; set; }
        public string Ddd { get;  set; }
        public string Number { get;  set; }
    }
        public class InsertPhoneViewModel
    {

        public string Ddd { get;  set; }
        public string Number { get;  set; }
        public Guid SupplierId {get; set;}
        public string Name {get;set;}
    }
}