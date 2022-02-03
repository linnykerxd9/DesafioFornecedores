using System.Collections.Generic;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Tools;
using FluentValidation;

namespace DesafioFornecedores.Domain.Models
{
    public class Category : Entity, IAggregateRoot
    {
        public bool Active { get; private set; }
        public string Name { get; private set; }
        public List<Product> Product { get; private set; } = new List<Product>();
        protected Category() { }
        public Category(bool active, string name)
        {
            SetActive(active);
            SetName(name);
            isValid();
        }
        public void SetName(string name){
            if(string.IsNullOrEmpty(name))
            throw new DomainExceptions("the category name cannot be empty");

            if(name.Length < 5)
            throw new DomainExceptions("the size of the category name is incorrect");

            Name = name;
        }
        public void SetActive(bool status) {
            Active = status;
        }
          public override bool isValid(){
            var result = new CategoryValidator().Validate(this);
            return result.IsValid;
        }
    }

    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                    .MaximumLength(100)
                    .WithMessage("the Name field for can have up to 100 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Name is null");
        }
    }
    
}