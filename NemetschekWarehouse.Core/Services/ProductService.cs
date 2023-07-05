using Microsoft.EntityFrameworkCore;
using NemetschekWarehouse.Core.Contracts;
using NemetschekWarehouse.Core.Models.Product;
using NemetschekWarehouse.Infrastructure.data;
using NemetschekWarehouse.Infrastructure.Data.Entities;

namespace NemetschekWarehouse.Core.Services;

public class ProductService:IProduct
{

    private readonly WarehouseDb _warehouseDb;

    public ProductService(WarehouseDb warehouse)
    {
        _warehouseDb = warehouse;
    }
    public async Task AddAsync(AddProductModel model)
    {
        var productModel = new Product
        {
            Name = model.Name,
            ImageUrl = model.ImageUrl,
            Price = model.Price,
            Quantity = model.Quantity,
            TypeId = model.TypeId

        };

        await _warehouseDb.AddAsync(productModel);
        await _warehouseDb.SaveChangesAsync();
    }

    public  async Task<IEnumerable<TypeViewModel>> GetTypesAsync()
    {
        var types = await _warehouseDb.Types.Select(x => new TypeViewModel
        {
            Id = x.Id,
            Name = x.Name,
        }).ToListAsync();

        return types;
    }

    public async Task<IEnumerable<ProductViewModel>> GetProductAsync()
    {
        var productModel = await this._warehouseDb.Products.Select(x => new ProductViewModel
        {
            Name = x.Name,
            ImageUrl = x.ImageUrl,
            Price = x.Price,
            Quantity = x.Quantity,
            Type = x.Type.Name
        }).ToListAsync();

        return productModel;
    }
}