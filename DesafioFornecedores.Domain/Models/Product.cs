using DesafioFornecedores.Domain.Tools;

namespace DesafioFornecedores.Domain.Models
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string BarCode { get; private set; }
        public int QuantityStock { get; private set; }
        public bool Active { get; private set; }
        public decimal PriceSales { get; private set; }
        public decimal PricePurchase { get; private set; }

        protected Product() { }
        public Product(string name, string barCode, int quantityStock, bool active, decimal priceSales, decimal pricePurchase)
        {
            SetName(name);
            SetBarCode(barCode);
            SetQuantityStock(quantityStock);
            SetPriceSales(priceSales);
            SetPricePurchase(pricePurchase);
            Active = active;
        }
        public void SetName(string name){
            StringEmptyOrNull(name,"Product Name");
            SizeIsValid(name.Length, 5, 100,"Product");
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
        public void Activate() {
            Active = true;
        }
        public void Disable() {
            Active = false;
        }


        private void StringEmptyOrNull(string text,string message){
             if(string.IsNullOrEmpty(text))
             throw new DomainExceptions($"{message} cannot be empty");
        }
        private void SizeIsValid(int value, int lengMin, int lengMax,string message)
         {
                if(value < lengMin || value> lengMax)
                throw new DomainExceptions($"the {message} name can only be between {lengMin} to {lengMax} characters");
         }
    }
}