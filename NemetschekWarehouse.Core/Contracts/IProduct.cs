using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NemetschekWarehouse.Core.Models.Product;

namespace NemetschekWarehouse.Core.Contracts
{
    public interface IProduct
    {
        public Task AddAsync (AddProductModel model);

        public Task<IEnumerable<TypeViewModel>> GetTypesAsync();

        public Task<IEnumerable<ProductViewModel>> GetProductAsync();

    }
}
