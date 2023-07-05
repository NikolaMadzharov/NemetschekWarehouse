using Microsoft.AspNetCore.Mvc;
using NemetschekWarehouse.Core.Contracts;
using NemetschekWarehouse.Core.Models.Product;

namespace NemetschekWarehouse.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _ProductService;

        public ProductController(IProduct ProductService)
        {
            _ProductService = ProductService;
        }


        [HttpGet]
        public async Task<IActionResult> All(int page = 1)
        {
            var products = await _ProductService.GetProductAsync();

            int pageSize = 3;

            var totalCount = products.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            var pagedProduts = products.Skip((page - 1) * pageSize).Take(pageSize);

            var viewModel = new PagedProductViewModel()
            {
                ProductS = pagedProduts,
                PageIndex = page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var typesVM = await _ProductService.GetTypesAsync();

            var productVM = new AddProductModel
            {
                Types = typesVM
            };

            return this.View(productVM);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductModel model)
        {

            await this._ProductService.AddAsync(model);

            return RedirectToAction("Index", "Home");
        }
    }
}
