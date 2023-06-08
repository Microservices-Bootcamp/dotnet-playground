using System;
using System.ComponentModel.DataAnnotations;

namespace src.Controllers.Dtos
{
    public class Product
    {
        [Required(ErrorMessage ="Product can not be created without {0}")]
        public string Name { get; set; }

        [Required]
        public string Sku { get; set; }

        [Range(1,10000)]
        public decimal Price { get; set; }
    }

}