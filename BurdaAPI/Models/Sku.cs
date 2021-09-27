using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogAPI.Models
{
    public class Sku
    {
        [Key]
        public Guid Id { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid ProductId { get; set; }
    }
}
