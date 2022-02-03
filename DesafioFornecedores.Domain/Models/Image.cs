using System;
using DesafioFornecedores.Domain.Tools;

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
        }

        public void SetImage(string imagePath){
            if(!System.IO.File.Exists(imagePath)) throw new DomainExceptions("File not exists");

            ImagePath = imagePath;
        }

        public void SetProductId(Guid id){
            if(string.IsNullOrEmpty(id.ToString())) throw new DomainExceptions("Id is null or empty");
            
            ProductId = id;
        }
    }
}