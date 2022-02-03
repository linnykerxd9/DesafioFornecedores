using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioFornecedores.WebApp.Models
{
    public class CategoryViewModel
    {
        public bool Active { get;  set; }
        public string Name { get;  set; }
        public List<ProductViewModel> Product { get; set; }
    }
     public class CategoryCreateViewModel
    {
        [Required]
        public bool Active { get;  set; }
        [Required]
        [StringLength(100)]
        public string Name { get;  set; }
    }
      public class CategoryUpdateOrEditViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public bool Active { get;  set; }
        [Required]
        [StringLength(100)]
        public string Name { get;  set; }
    }
}