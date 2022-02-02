using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioFornecedores.WebApp.Models
{
    public class AddressViewModel
    {
        [Required]
        [StringLength(8,MinimumLength = 8)]
        public string ZipCode { get;  set; }
        [Required]
        [StringLength(256,MinimumLength = 2)]
        public string Street { get;  set; }
        [Required]
        [StringLength(10)]
        public string Number { get;  set; }
        [Required]
        [StringLength(256)]
        public string Neighborhood { get;  set; }
        [Required]
        [StringLength(256)]
        public string City { get;  set; }
        [Required]
        [StringLength(256,MinimumLength =2)]
        public string State { get;  set; }
        [StringLength(256)]
        public string Complement { get;  set; }
        [StringLength(256)]
        public string Reference { get;  set; }
    }
    public class AddressUpdateViewModel
    {
        public Guid Id { get; set; }
        [StringLength(8,MinimumLength = 8)]
        public string ZipCode { get;  set; }
        [Required]
        [StringLength(256,MinimumLength = 2)]
        public string Street { get;  set; }
        [Required]
        [StringLength(10)]
        public string Number { get;  set; }
        [Required]
        [StringLength(256)]
        public string Neighborhood { get;  set; }
        [Required]
        [StringLength(256)]
        public string City { get;  set; }
        [Required]
        [StringLength(256,MinimumLength =2)]
        public string State { get;  set; }
        [StringLength(256)]
        public string Complement { get;  set; }
        [StringLength(256)]
        public string Reference { get;  set; }
    }
}