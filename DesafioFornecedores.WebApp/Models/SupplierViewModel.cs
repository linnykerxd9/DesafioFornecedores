using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
    public class EditSupplierViewModel
    {
        //atributos gerais
        public Guid Id {get; set;}
        public bool Active { get;  set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string FantasyName { get;  set; }
        
        public  EmailUpdateViewModel Email { get; set;}
        public AddressUpdateViewModel Address { get; set; }
        public List<UpdatePhoneViewModel> Phone { get; set; } = new List<UpdatePhoneViewModel>(3);
        public UpdatePhoneViewModel FirstPhone {get; set;} = new UpdatePhoneViewModel();
        public UpdatePhoneViewModel SecondPhone {get ; set; } = new UpdatePhoneViewModel();
        public UpdatePhoneViewModel ThirdPhone {get; set;} = new UpdatePhoneViewModel();
        //atributos fornecedor fisico [StringLength(256, MinimumLength = 10)]
        public string FullName { get;  set; }
        [StringLength(11,MinimumLength = 11)]
        public string Cpf { get;  set; }
        public DateTime BirthDate  { get;  set; }

        //atributos fornecedor juridico
        [StringLength(256)]
        public string CompanyName { get; set; }
        [StringLength(14,MinimumLength = 14)]
        public string Cnpj { get; set; }
        public DateTime? OpenDate { get; set; }
    }
    public class CreateSupplierViewModel
    {
        //atributos gerais
        [Required]
        public bool Active { get;  set; }
        
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string FantasyName { get;  set; }
        
        public  EmailViewModel Email { get; set;}
        public AddressViewModel Address { get; set; }
        public List<PhoneViewModel> Phone { get; set; } = new List<PhoneViewModel>(3);
        public PhoneViewModel FirstPhone {get; set;} = new PhoneViewModel();
        public PhoneViewModel SecondPhone {get ; set; } = new PhoneViewModel();
        public PhoneViewModel ThirdPhone {get; set;} = new PhoneViewModel();
        //atributos fornecedor fisico
        [StringLength(256, MinimumLength = 10)]
        public string FullName { get;  set; }
        [StringLength(11,MinimumLength = 11)]
        public string Cpf { get;  set; }
        public DateTime BirthDate  { get;  set; }

        //atributos fornecedor juridico
        [StringLength(256)]
        public string CompanyName { get; set; }
        [StringLength(14,MinimumLength = 14)]
        public string Cnpj { get; set; }
        public DateTime? OpenDate { get; set; }
    }
    public class DeleteSupplierViewModel
    {
        public Guid Id {get; set;}
        public bool Active { get;  set; }
        public string FantasyName { get;  set; }
    }
}