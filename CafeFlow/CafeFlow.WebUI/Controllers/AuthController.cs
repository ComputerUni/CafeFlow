using CafeFlow.DataAccess.Repositories.Customers;
using CafeFlow.DTO.Auth;
using CafeFlow.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CafeFlow.WebUI.Controllers
{
    public class AuthController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager, ICustomerRepository _customerRepository) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if(user == null)
            {
                ModelState.AddModelError(string.Empty, "Bu mail sistemde kayıtlı değil");
                return View(dto);
            }

            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre hatalı");
                return View(dto);
            }

            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "Default");
            }
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            if (dto.Password != dto.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Şifreler birbirleriyle uyumlu değil.");
                return View(dto);
            }

            var user = new AppUser
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.Username,
                PhoneNumber = dto.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if(!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return View(dto);
            }

            await _userManager.AddToRoleAsync(user, "Customer");

            var customer = new Customer
            {
                AppUserId = user.Id,
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Phone = user.PhoneNumber
            };

            await _customerRepository.CreateAsync(customer);

            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}
