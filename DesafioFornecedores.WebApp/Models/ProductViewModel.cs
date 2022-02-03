using System;
using System.Collections.Generic;
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
         public string Name { get;  set; }
        public string BarCode { get;  set; }
        public int QuantityStock { get;  set; }
        public bool Active { get;  set; }
        public decimal PriceSales { get;  set; }
        public decimal PricePurchase { get;  set; }
        public Guid CategoryId { get; set; }
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
        public ICollection<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();
    }
}