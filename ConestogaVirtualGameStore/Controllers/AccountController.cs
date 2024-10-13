using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyVirtualGameStore.AppDbContext;

namespace ConestogaVirtualGameStore.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly VirtualGameStoreContext _virtualGameStoreContext;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,VirtualGameStoreContext virtualGameStoreContext)
        {
                _userManager = userManager;
            _signInManager = signInManager;
            _virtualGameStoreContext = virtualGameStoreContext;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {

                    //Assign role to the user, default is 'Member'
                    await _userManager.AddToRoleAsync(user, "Member");

                    var passwordHasher = new PasswordHasher<ApplicationUser>();
                    var hashedPassword = passwordHasher.HashPassword(user, model.Password);

                    var member = new Member
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = hashedPassword,
                        Register_Date = DateTime.Now
                    };

                    _virtualGameStoreContext.Add(member);
                    await _virtualGameStoreContext.SaveChangesAsync();

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    // Find the member by email from the custom Member table
                    var member = _virtualGameStoreContext.Members.FirstOrDefault(m => m.Email == model.Email);

                    if (member != null)
                    {
                        var passwordHasher = new PasswordHasher<ApplicationUser>();
                        var result = passwordHasher.VerifyHashedPassword(user, member.Password, model.Password);

                        if (result == PasswordVerificationResult.Success)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: model.RememberMe);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
    return View(model);
    }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
