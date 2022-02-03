using System;
using System.Collections.Generic;
using DesafioFornecedores.Domain.Interface.Repository;
using DesafioFornecedores.Domain.Tools;
using FluentValidation;

namespace DesafioFornecedores.Domain.Models
{
    public class Product : Entity, IAggregateRoot
    {
        public bool Active { get; private set; }
        public string Name { get; private set; }
        public string BarCode { get; private set; }
        public int QuantityStock { get; private set; }
        public decimal PriceSales { get; private set; }
        public decimal PricePurchase { get; private set; }
        public Guid CategoryId { get;private set; }
        public Category Category { get; set; }
        public Guid SupplierId { get;private set; }
        public Supplier Supplier { get; set; }
        public List<Image> Image { get; private set; } = new List<Image>();

        protected Product() { }
        public Product(string name, string barCode, int quantityStock, decimal priceSales, decimal pricePurchase, bool active,Guid categoryId,Image images)
        {
            SetName(name);
            SetBarCode(barCode);
            SetQuantityStock(quantityStock);
            SetPriceSales(priceSales);
            SetPricePurchase(pricePurchase);
            SetCategoryId(categoryId);
            SetImage(images);
            SetActive(active);
            isValid();
        }
        public void SetName(string name){
            StringEmptyOrNull(name,"Product Name");
            Name = name;
        }
        public void SetBarCode(string barCode){
            StringEmptyOrNull(barCode,"Bar Code");

            BarCode = barCode;
        }
        public void SetQuantityStock(int stock){
            QuantityStock = stock;
        }
        public void SetPriceSales(decimal priceSale){
            if(priceSale < 0)
                throw new DomainExceptions("sale price can not be negative");
            
            PriceSales = priceSale;
        }
        public void SetPricePurchase(decimal privePurchase){
            if(privePurchase < 0)
                throw new DomainExceptions("sale price can not be negative");
            
            PricePurchase = privePurchase;
        }
        public void SetImage(Image image){
            if(image == null) throw new DomainExceptions("Image is null");
            image.SetProductId(this.Id);
           Image.Add(image);
        }
        public void SetCategoryId(Guid id){
            if(string.IsNullOrEmpty(id.ToString())) throw new DomainExceptions("Category Id is null or empty");

            CategoryId = id;
        }
        public void SetActive(bool status) {
            Active = status;
        }


        private void StringEmptyOrNull(string text,string message){
             if(string.IsNullOrEmpty(text))
             throw new DomainExceptions($"{message} cannot be empty");
        }
      
    public override bool isValid(){
            var result = new ProductValidator().Validate(this);
            return result.IsValid;
        }
    }

    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Active)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Active is null");
              RuleFor(x => x.Name)
                    .MaximumLength(256)
                    .WithMessage("the Name field for can have up to 256 characters").NotEmpty()
                    .NotNull()
                    .WithMessage("Name is null");
              RuleFor(x => x.BarCode)
                    .MaximumLength(100)
                    .WithMessage("the Name field for can have up to 100 characters")
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("BarCode is null");
              RuleFor(x => x.QuantityStock)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("QuantityStock is null");
              RuleFor(x => x.PricePurchase)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("PricePurchase is null");
              RuleFor(x => x.PriceSales)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("PriceSales is null");
        }
    }
}