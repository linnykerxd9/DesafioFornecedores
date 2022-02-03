using System;
using DesafioFornecedores.Domain.Tools;
using FluentValidation;

namespace DesafioFornecedores.Domain.Models
{
    public class Email : Entity
    {
        public string EmailAddress { get; private set; }
        public Guid SupplierId {get; private set;}
        public virtual Supplier Supplier { get; set;}
        protected Email() {}
        public Email(string emailAddress, Guid supplierId)
        {
            SetEmail(emailAddress);
            SetSupplierId(supplierId);
            isValid();
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
    public override bool isValid(){
            var result = new EmailValidator().Validate(this);
            return result.IsValid;
        }
    }

    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(x => x.EmailAddress.IsValidEmail()).Equals(true);
        }
    }
}