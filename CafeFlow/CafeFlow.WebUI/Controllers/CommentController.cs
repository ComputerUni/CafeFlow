using CafeFlow.Business.Abstract;
using CafeFlow.DTO.Comment;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeFlow.WebUI.Controllers
{
    public class CommentController(ICommentService _commentService, ICustomerService _customerService) : Controller
    {
        public async Task<IActionResult> Create(CreateCommentDto commentDto)
        {
            if(User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer = await _customerService.GetByAppUserIdAsync(int.Parse(userId));
                if(customer != null)
                {
                    commentDto.CustomerId = customer.Id;
                }
               
                if (string.IsNullOrWhiteSpace(commentDto.CustomerName))
                {
                    commentDto.CustomerName = User.Identity.Name;
                }
            }
            else
            {
                commentDto.CustomerId = null;
            }
                
            await _commentService.CreateAsync(commentDto);
            return RedirectToAction("Detail", "Product", new { id = commentDto.ProductId });
        }
    }
}
