using DesafioFornecedores.Domain.Tools;

namespace DesafioFornecedores.Domain.Models
{
    public class Image : Entity
    {
        public string ImagePath { get; private set; }

        protected Image() { }
        public Image(string imagePath)
        {
            SetImage(imagePath);
        }

        public void SetImage(string imagePath){
            if(!System.IO.File.Exists(imagePath)) throw new DomainExceptions("File not exists");

            ImagePath = imagePath;
        }
    }
}