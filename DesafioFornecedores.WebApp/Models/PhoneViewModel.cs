using System;

namespace DesafioFornecedores.WebApp.Models
{
    public class PhoneViewModel
    {
        public string Ddd { get;  set; }
        public string Number { get;  set; }
    }
    public class UpdatePhoneViewModel
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
    public class DeletePhoneViewModel
    {
        public Guid Id { get; set; }
        public string Ddd { get;  set; }
        public string Number { get;  set; }
        public Guid SupplierId { get; set; }
    }
    public class SupplieDeletePhoneViewModel
    {
        public string FantasyName { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public DeletePhoneViewModel Phone { get; set; }
    }
}