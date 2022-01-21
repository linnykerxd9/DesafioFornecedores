using System;

namespace DesafioFornecedores.Domain.Tools
{
    public class DomainExceptions : Exception
    {
        public DomainExceptions(string message) : base(message)
        {
        }
    }
}