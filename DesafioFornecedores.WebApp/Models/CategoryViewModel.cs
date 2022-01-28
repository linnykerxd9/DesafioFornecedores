using System.Collections.Generic;

namespace DesafioFornecedores.WebApp.Models
{
    public class CategoryViewModel
    {
        public bool Active { get;  set; }
        public string Name { get;  set; }
        public List<ProductViewModel> Product { get; set; }
    }
}