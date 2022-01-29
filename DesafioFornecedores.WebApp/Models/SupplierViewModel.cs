using System;
using System.Collections.Generic;

namespace DesafioFornecedores.WebApp.Models
{
    public class SupplierCreateViewModel
    {
        //atributos gerais
        public bool Active { get;  set; }
        public string FantasyName { get;  set; }
        
        public EmailViewModel Email { get; set;}
        public AddressViewModel Address { get; set; }
        public PhoneViewModel Phone { get; set; }

        //atributos fornecedor fisico
         public string FullName { get;  set; }
        public string Cpf { get;  set; }
        public DateTime BirthDate  { get;  set; }


        //atributos fornecedor juridico
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public DateTime? OpenDate { get; set; }

    }
     public class SupplierListViewModel
    {
        //atributos gerais
        public bool Active { get;  set; }
        public string FantasyName { get;  set; }
        
        public EmailViewModel Email { get; set;}
        public AddressViewModel Address { get; set; }
        public List<PhoneViewModel> Phone { get; set; } = new List<PhoneViewModel>();

        //atributos fornecedor fisico
         public string FullName { get;  set; }
        public string Cpf { get;  set; }
        public DateTime BirthDate  { get;  set; }


        //atributos fornecedor juridico
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public DateTime? OpenDate { get; set; }

    }
}