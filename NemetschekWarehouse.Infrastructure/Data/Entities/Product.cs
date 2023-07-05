using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace NemetschekWarehouse.Infrastructure.Data.Entities
{
    public class Product
    {
        [Key]
        
        public int Id { get; set; }

        [Required] public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; } = decimal.Zero;

        [Required] public string ImageUrl { get; set; } = string.Empty;

        [Required] public int Quantity { get; set; }


        [ForeignKey("Type")]
        public int TypeId { get; set; } 
        public  virtual Type Type { get; set; }


    }
}
