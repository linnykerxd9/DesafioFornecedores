using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioFornecedores.WebApp.Models
{
    public class ImageViewModel
    {
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }
    }
    public class ImageRemoveViewModel
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
    }
     public class ImageInsertOrDeleteViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImagePath { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}