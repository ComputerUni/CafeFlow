using CafeFlow.Business.Abstract;
using CafeFlow.DTO.Table;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TableController(ITableService _tableService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var tables = await _tableService.GetAllAsync();
            return View(tables);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTableDto dto)
        {
            await _tableService.CreateAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var table = await _tableService.GetByIdAsync(id);
            return View(table);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTableDto dto)
        {
            await _tableService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var table = await _tableService.GetByIdAsync(id);
            await _tableService.DeleteAsync(table.Id);
            return RedirectToAction("Index");
        }
    }
}
