using Dashboard_DW_V2.Models;
using Dashboard_DW_V2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard_DW_V2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager= roleManager;

        }
        [Authorize(Roles = "Admin")]
        public IActionResult List()
        {
            var UsersList = new RegisterListViewModel
            {
                Users = _userManager.Users.ToList()
                
            };
            return View(UsersList);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Register(Register model)
        {          
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FirstName= model.FirstName,
                    LastName= model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    IsAdmin=model.IsAdmin
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (user.IsAdmin)
                    {
                        var defaultrole = _roleManager.FindByNameAsync("admin").Result;
                        if (defaultrole != null)
                        {
                            IdentityResult roleresult = await _userManager.AddToRoleAsync(user, defaultrole.Name);
                        }
                    }
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(string? Id)
        {
            var User = await _userManager.FindByIdAsync(Id);
            if (User == null)
            {
                return NotFound();
            }
            var UserEdit = new RegisterEditViewModel
            {
                Id = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Email = User.Email,
                IsAdmin = User.IsAdmin
            };
            return View(UserEdit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(RegisterEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var User = await _userManager.FindByIdAsync(model.Id);
                User.Id = model.Id;
                User.FirstName= model.FirstName;
                User.LastName= model.LastName;
                User.Email= model.Email;
                User.IsAdmin= model.IsAdmin;         
                
                var result = await _userManager.UpdateAsync(User);
                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Account");
                }
            }
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string? Id)
        {
            var User = await _userManager.FindByIdAsync(Id);
            if (User == null)
            {
                return NotFound();
            }
            var UserEdit = new RegisterEditViewModel
            {
                Id = User.Id,
                FirstName = User.FirstName,
                LastName = User.LastName,
                Email = User.Email,
                IsAdmin = User.IsAdmin
            };
            return View(UserEdit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(RegisterEditViewModel model)
        {

            var user = _userManager.Users.FirstOrDefault(x => x.Id == model.Id);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("List", "Account");
                }
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var Result = await _signInManager.PasswordSignInAsync
                      (model.Email, model.Password, model.RememberMe, false);
                if (Result.Succeeded)
                {
                    User user = _userManager.Users.Where(u => u.Email.Equals(model.Email)).FirstOrDefault();

                    if (user.IsAdmin)
                        return RedirectToAction("List", "Account");
                    else
                    {
                        return RedirectToAction("Index", "Home");


                    }
                }
                ModelState.AddModelError(String.Empty, "Invalid Email Or Password");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


    }
}

