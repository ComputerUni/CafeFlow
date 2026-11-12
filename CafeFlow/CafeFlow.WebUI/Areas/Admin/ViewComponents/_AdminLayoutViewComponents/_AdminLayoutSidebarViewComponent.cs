using CafeFlow.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Areas.Admin.ViewComponents._AdminLayoutViewComponents
{
    public class _AdminLayoutSidebarViewComponent(UserManager<AppUser> _userManager) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.FullName = "Yönetici";
            ViewBag.Initials = "AD";
            ViewBag.Role = "Admin";

            var user = await _userManager.GetUserAsync(UserClaimsPrincipal);

            if(user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                ViewBag.FullName = $"{user.FirstName} {user.LastName}".Trim();
                ViewBag.Role = roles.FirstOrDefault() ?? "Admin";

                var first = !string.IsNullOrWhiteSpace(user.FirstName) ? user.FirstName[0].ToString().ToUpper() : "";
                var last = !string.IsNullOrWhiteSpace(user.LastName) ? user.LastName[0].ToString().ToUpper() : "";
                ViewBag.Initials = string.IsNullOrEmpty(first + last) ? "AD" : first + last;
            }

            return View();
        }
    }
}
