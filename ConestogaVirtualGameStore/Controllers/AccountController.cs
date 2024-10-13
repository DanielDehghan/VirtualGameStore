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

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, VirtualGameStoreContext virtualGameStoreContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _virtualGameStoreContext = virtualGameStoreContext;
        }

        // Display Register form
        public IActionResult Register()
        {
            return View();
        }

        // Register action
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Assign role to the user, default is 'Member'
                    await _userManager.AddToRoleAsync(user, "Member");

                    // Hash the password to store in the Members table
                    var passwordHasher = new PasswordHasher<ApplicationUser>();
                    var hashedPassword = passwordHasher.HashPassword(user, model.Password);

                    var member = new Member
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email,
                        Password = hashedPassword,  // Store hashed password
                        Register_Date = DateTime.Now
                    };

                    // Save the member information
                    _virtualGameStoreContext.Add(member);
                    await _virtualGameStoreContext.SaveChangesAsync();

                    // Sign the user in automatically after registration
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                // Handle errors in registration
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            // Return to registration view if invalid
            return View(model);
        }

        // Display Login form
        public IActionResult Login()
        {
            return View();
        }

        // Login action
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by email from AspNetUsers
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    // Attempt to sign in the user using PasswordSignInAsync
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        // Redirect to home if login is successful
                        return RedirectToAction("Index", "Home");
                    }
                }

                // If the login attempt failed
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            // Return to login view if invalid
            return View(model);
        }

        // Logout action
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
