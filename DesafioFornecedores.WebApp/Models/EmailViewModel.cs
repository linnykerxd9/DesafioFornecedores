using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioFornecedores.WebApp.Models
{
    public class EmailViewModel
    {
        [Required]
        public string EmailAddress { get;  set; }
    }
    public class EmailUpdateViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string EmailAddress { get;  set; }
      
    }
}