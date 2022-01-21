namespace DesafioFornecedores.Domain.Models
{
    public class Supplier : Entity
    {
        public bool Active { get; private set; }

        protected void Activate() {
            Active = true;
        }
        protected void Disable() {
            Active = false;
        }
    }
}