using CafeFlow.Business.Abstract;
using CafeFlow.DTO.Comment;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Controllers
{
    public class CommentController(ICommentService _commentService) : Controller
    {
        public async Task<IActionResult> Create(CreateCommentDto commentDto)
        {
            await _commentService.CreateAsync(commentDto);
            return RedirectToAction("Detail", "Product", new { id = commentDto.ProductId });
        }
    }
}
