using DesafioFornecedores.Domain.Tools;

namespace DesafioFornecedores.Domain.Models
{
    public class Email : Entity
    {
        public string EmailAddress { get; private set; }

        protected Email() {}
        public Email(string emailAddress)
        {
            SetEmail(emailAddress);
        }
        public void SetEmail(string emailAddress)
        {
            if(!emailAddress.IsValidEmail()) throw new DomainExceptions("Email is invalid");
            EmailAddress = emailAddress;
        }
    }
}