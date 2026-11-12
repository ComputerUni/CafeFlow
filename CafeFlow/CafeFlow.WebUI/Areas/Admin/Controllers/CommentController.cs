using CafeFlow.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController(ICommentService _commentService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var comments = await _commentService.GetAllWithDetailsAsync();
            return View(comments);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            await _commentService.ChangeStatusAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
