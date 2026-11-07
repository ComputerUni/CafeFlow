using CafeFlow.Business.Abstract;
using CafeFlow.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CafeFlow.WebUI.ViewComponents._CartLayoutViewComponents
{
    public class _CartLayoutScriptsViewComponent(IProductService _productService, ITableService _tableService) : ViewComponent
    {
        private static readonly JsonSerializerOptions _json = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _productService.GetAllAsync();
            var tables = await _tableService.GetAllAsync();

            var vm = new CartLayoutScriptsViewModel
            {
                ProductsJson = JsonSerializer.Serialize(products.Select(p => new
                {
                    id = p.Id,
                    name = p.Name,
                    category = p.CategoryName,
                    price = p.Price,
                    image = p.ImageUrl,
                    description = p.Description,
                    customizable = p.IsCustomizable
                }), _json),

                TableRegistryJson = JsonSerializer.Serialize(
                tables
                    .Where(t => t.IsAvailable)
                    .ToDictionary(
                        t => t.QRCode,
                        t => new { tableNumber = t.TableNumber }
                    ), _json)
            };

            return View(vm);
        }
    }
}
