using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioFornecedores.WebApp.Models
{
    public class PhoneViewModel
    {   
        [StringLength(3,MinimumLength =2)]
        public string Ddd { get;  set; }
        [StringLength(9,MinimumLength =9)]
        public string Number { get;  set; }
    }
    public class UpdatePhoneViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(3,MinimumLength =2)]
        public string Ddd { get;  set; }
        [Required]
        [StringLength(9,MinimumLength =9)]
        public string Number { get;  set; }

    }
        public class InsertPhoneViewModel
    {
        [Required]
        [StringLength(3,MinimumLength =2)]
        public string Ddd { get;  set; }
        [Required]
        [StringLength(9,MinimumLength =8)]
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