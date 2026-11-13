using CafeFlow.Business.Abstract;
using CafeFlow.DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CafeFlow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController(IProductService _productService, ICategoryService _categoryService) : Controller
    {
        private async Task LoadCategoriesAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            if(!ModelState.IsValid)
            {
                await LoadCategoriesAsync();
                return View(dto);
            }

            await _productService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            await LoadCategoriesAsync();
            var product = await _productService.GetByIdAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            await _productService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeActive(int id)
        {
            await _productService.ChangeActiveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeCustomizable(int id)
        {
            await _productService.ChangeCustomizableAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeFeature(int id)
        {
            await _productService.ChangeFeatureAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
