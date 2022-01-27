namespace DesafioFornecedores.WebApp.Models
{
    public class ProductViewModel
    {
         public string Name { get;  set; }
        public string BarCode { get;  set; }
        public int QuantityStock { get;  set; }
        public bool Active { get;  set; }
        public decimal PriceSales { get;  set; }
        public decimal PricePurchase { get;  set; }
    }
}