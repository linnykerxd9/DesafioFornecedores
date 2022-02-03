using System;
using System.Collections.Generic;
using DesafioFornecedores.Domain.Models;

namespace DesafioFornecedores.Infra.Models
{
    public class ProductDTO
    {
        public string Name { get;  set; }
        public string BarCode { get;  set; }
        public int QuantityStock { get;  set; }
        public bool Active { get;  set; }
        public decimal PriceSales { get;  set; }
        public decimal PricePurchase { get;  set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<Image> Image { get;  set; } = new List<Image>();
    }
}