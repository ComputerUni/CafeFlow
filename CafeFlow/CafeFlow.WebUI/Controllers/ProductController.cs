using CafeFlow.Business.Abstract;
using CafeFlow.DTO.Category;
using CafeFlow.DTO.Comment;
using CafeFlow.DTO.Product;
using CafeFlow.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Controllers
{
    public class ProductController(IProductService _productService, ICommentService _commentService, ICategoryService _categoryService, ICustomerService _customerService) : Controller
    {
        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productService.GetProductWithCategoryByIdAsync(id);
            if (product is null)
                return NotFound();

            var comments = await _commentService.GetCommentsByProductId(id);
            var products = await _productService.GetAllAsync();        
            var categories = await _categoryService.GetAllAsync();     

            var viewModel = new ProductDetailPageViewModel
            {
                Product = product,
                Comments = comments ?? new List<CommentListDto>(),
                CurrentProductId = id,
                Products = products ?? new List<ProductListDto>(),     
                Categories = categories ?? new List<CategoryListDto>() 
            };

            return View(viewModel);
        }
    }
}
