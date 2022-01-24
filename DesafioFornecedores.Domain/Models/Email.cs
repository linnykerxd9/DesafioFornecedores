using System;
using DesafioFornecedores.Domain.Tools;

namespace DesafioFornecedores.Domain.Models
{
    public class Email : Entity
    {
        public string EmailAddress { get; private set; }
        public Guid SupplierId {get; private set;}
        protected Email() {}
        public Email(string emailAddress, Guid supplierId)
        {
            SetEmail(emailAddress);
            SetSupplierId(supplierId);
        }
        public void SetEmail(string emailAddress)
        {
            if(!emailAddress.IsValidEmail()) throw new DomainExceptions("Email is invalid");
            EmailAddress = emailAddress;
        }

        public void SetSupplierId(Guid id){
            if(string.IsNullOrEmpty(id.ToString())) throw new DomainExceptions("Id is null or empty");

            SupplierId = id;
        }
    }
}