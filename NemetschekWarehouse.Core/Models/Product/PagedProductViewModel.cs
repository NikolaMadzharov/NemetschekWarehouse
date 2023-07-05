namespace NemetschekWarehouse.Core.Models.Product;

public class PagedProductViewModel
{
    public IEnumerable<ProductViewModel> ProductS { get; set; }
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
}