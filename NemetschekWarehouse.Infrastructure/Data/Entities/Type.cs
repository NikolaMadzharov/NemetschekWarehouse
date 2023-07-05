using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemetschekWarehouse.Infrastructure.Data.Entities
{
    public class Type
    {
        public Type()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Product> Products { get; set; }


    }
}
