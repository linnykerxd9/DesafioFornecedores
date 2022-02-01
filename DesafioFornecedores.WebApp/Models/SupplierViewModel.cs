using System;
using System.Collections.Generic;

namespace DesafioFornecedores.WebApp.Models
{
     public class SupplierListViewModel
    {
        //atributos gerais
        public bool Active { get;  set; }
        public string FantasyName { get;  set; }
        
        public EmailViewModel Email { get; set;}
        public AddressViewModel Address { get; set; }
        public IEnumerable<PhoneViewModel> Phone { get; set; } = new List<PhoneViewModel>(3);

        //atributos fornecedor fisico
         public string FullName { get;  set; }
        public string Cpf { get;  set; }
        public DateTime BirthDate  { get;  set; }


        //atributos fornecedor juridico
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public DateTime? OpenDate { get; set; }

    }
       public class CreateOrEditSupplierViewModel
    {
        //atributos gerais
        public Guid Id {get; set;}
        public bool Active { get;  set; }
        public string FantasyName { get;  set; }
        
        public  EmailUpdateViewModel Email { get; set;}
        public AddressUpdateViewModel Address { get; set; }
        public List<UpdateOrDeletePhoneViewModel> Phone { get; set; } = new List<UpdateOrDeletePhoneViewModel>(3);
        public UpdateOrDeletePhoneViewModel FirstPhone {get; set;} = new UpdateOrDeletePhoneViewModel();
        public UpdateOrDeletePhoneViewModel SecondPhone {get ; set; } = new UpdateOrDeletePhoneViewModel();
        public UpdateOrDeletePhoneViewModel ThirdPhone {get; set;} = new UpdateOrDeletePhoneViewModel();
        //atributos fornecedor fisico
         public string FullName { get;  set; }
        public string Cpf { get;  set; }
        public DateTime BirthDate  { get;  set; }

        //atributos fornecedor juridico
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}