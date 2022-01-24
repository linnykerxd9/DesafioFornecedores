using System.Collections.Generic;
using DesafioFornecedores.Domain.Interface;
using DesafioFornecedores.Domain.Tools;

namespace DesafioFornecedores.Domain.Models
{
    public class Category : Entity, IAggregateRoot
    {
        public bool Active { get; private set; }
        public string Name { get; private set; }
        private List<Product> Product { get; set; }
        public IReadOnlyCollection<Product> Products { get{ return Product;} }
        protected Category() { }
        public Category(bool active, string name)
        {
            Active = active;
            SetName(name);
        }
        public void SetName(string name){
            if(string.IsNullOrEmpty(name))
            throw new DomainExceptions("the category name cannot be empty");

            if(name.Length < 5)
            throw new DomainExceptions("the size of the category name is incorrect");

            Name = name;
        }
        public void SetProduct(Product product){
            if(product == null) throw new DomainExceptions("Product is null");

            Product.Add(product);
        }
        public void Activate() {
            Active = true;
        }
        public void Disable() {
            Active = false;
        }
    }
}