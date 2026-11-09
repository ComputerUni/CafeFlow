using CafeFlow.DTO.Comment;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.ViewComponents._ProductDetailLayoutViewComponents
{
    public class _ProductDetailLayoutCreateCommentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int productId)
        {
            var model = new CreateCommentDto
            {
                ProductId = productId
            };
            return View(model);
        }
    }
}
