using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.WebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public bool Active { get;  set; }
         public string Name { get;  set; }
        public string BarCode { get;  set; }
        public int QuantityStock { get;  set; }
        public decimal PriceSales { get;  set; }
        public decimal PricePurchase { get;  set; }
        public CategoryViewModel Category {get;set;}
        public SupplierListViewModel Supplier {get;set;}
    }
    public class ProductCreateViewModel
    {
        [Required]
        [StringLength(256)]
         public string Name { get;  set; }
        [Required]
        [StringLength(256)]
        public string BarCode { get;  set; }
        [Required]
        public int QuantityStock { get;  set; }
        [Required]
        public bool Active { get;  set; }
        [Required]
        public decimal PriceSales { get;  set; }
        [Required]
        public decimal PricePurchase { get;  set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid SupplierId { get; set; }
        public ICollection<ImageViewModel> Image { get;  set; } = new List<ImageViewModel>();
        
        public ImageViewModel ImageUpload { get;  set; }
    }
    public class ProductDetailsViewModel
    {
        public bool Active { get;  set; }
        public string Name { get;  set; }
        public string BarCode { get;  set; }
        public int QuantityStock { get;  set; }
        public decimal PriceSales { get;  set; }
        public decimal PricePurchase { get;  set; }
        public CategoryViewModel Category {get;set;}
        public SupplierListViewModel Supplier {get;set;}
        public ICollection<ImageViewModel> Image { get; set; } = new List<ImageViewModel>();
    }
        public class ProductEditViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(256)]
         public string Name { get;  set; }
        [Required]
        [StringLength(256)]
        public string BarCode { get;  set; }
        [Required]
        public int QuantityStock { get;  set; }
        [Required]
        public bool Active { get;  set; }
        [Required]
        public decimal PriceSales { get;  set; }
        [Required]
        public decimal PricePurchase { get;  set; }
        [Required]
        public EditSupplierViewModel Supplier {get;set;}
        public CategoryViewModel Category {get;set;}
        public ICollection<ImageRemoveViewModel> Image { get; set; } = new List<ImageRemoveViewModel>();
    }
     public class ProductDeleteViewModel
    {
        public Guid Id { get; set; }
        public bool Active { get;  set; }
         public string Name { get;  set; }
        public string BarCode { get;  set; }
        public int QuantityStock { get;  set; }
        public decimal PriceSales { get;  set; }
        public decimal PricePurchase { get;  set; }
    }
}