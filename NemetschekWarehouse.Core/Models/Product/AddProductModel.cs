using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemetschekWarehouse.Core.Models.Product
{
    public class AddProductModel
    {


        [Required] 
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; } = decimal.Zero;

        [Required] 
        public string ImageUrl { get; set; } = string.Empty;

        [Required] 
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Type")]
        public int TypeId {get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; }
    }
}
