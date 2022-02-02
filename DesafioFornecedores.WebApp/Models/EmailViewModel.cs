using System;

namespace DesafioFornecedores.WebApp.Models
{
    public class EmailViewModel
    {
        public string EmailAddress { get;  set; }
      
    }
    public class EmailUpdateViewModel
    {
        public Guid Id { get; set; }
        public string EmailAddress { get;  set; }
      
    }
}