using System;
using DesafioFornecedores.Domain.Tools;
using FluentValidation;

namespace DesafioFornecedores.Domain.Models
{
    public class Image : Entity
    {
        public string ImagePath { get; private set; }
        public Guid ProductId { get; private set; }
        public Product Product{get; set;}
        protected Image() { }
        public Image(string imagePath,Guid productId)
        {
            SetImage(imagePath);
            SetProductId(productId);
            isValid();
        }

        public void SetImage(string imagePath){
            if(string.IsNullOrEmpty(imagePath)) throw new DomainExceptions("imagePath is null");

            ImagePath = imagePath;
        }

        public void SetProductId(Guid id){
            if(string.IsNullOrEmpty(id.ToString())) throw new DomainExceptions("Id is null or empty");
            
            ProductId = id;
        }
     public override bool isValid(){
            var result = new ImageValidator().Validate(this);
            return result.IsValid;
        }
    }

    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.ImagePath)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("ImagePath is null");
        }
    }
}