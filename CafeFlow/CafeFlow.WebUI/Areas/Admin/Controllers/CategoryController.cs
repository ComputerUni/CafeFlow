using CafeFlow.Business.Abstract;
using CafeFlow.DTO.Category;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(ICategoryService _categoryService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            await _categoryService.CreateAsync(dto);
            return RedirectToAction("Index");
        }
    }
}
