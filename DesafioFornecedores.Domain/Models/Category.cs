using DesafioFornecedores.Domain.Tools;

namespace DesafioFornecedores.Domain.Models
{
    public class Category : Entity
    {
        public bool Active { get; private set; }
        public string Name { get; private set; }
        
        protected Category() { }
        public Category(bool active, string name)
        {
            Active = active;
            SetName(name);
        }

        public void Activate() {
            Active = true;
        }
        public void Disable() {
            Active = false;
        }
        public void SetName(string name){
             if(string.IsNullOrEmpty(name))
             throw new DomainExceptions("the category name cannot be empty");

               if(name.Length < 5)
                throw new DomainExceptions("the size of the category name is incorrect");
                
            Name = name;
        }
    }
}