using System.ComponentModel.DataAnnotations;

namespace NemetschekWarehouse.Core.Models.Product;

public class ProductViewModel
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; } = decimal.Zero;

    [Required]
    public string ImageUrl { get; set; } = string.Empty;

    [Required]
    public int Quantity { get; set; }

    [Required]
    public string Type { get; set; }
}