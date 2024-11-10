using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ConestogaVirtualGameStore.AppDbContext;
using ConestogaVirtualGameStore.Services;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace ConestogaVirtualGameStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly VirtualGameStoreContext _virtualGameStoreContext;
        private readonly EmailService _emailService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, VirtualGameStoreContext virtualGameStoreContext, EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _virtualGameStoreContext = virtualGameStoreContext;
            _emailService = emailService;
        }


        public IActionResult Register()
        {
            return View();
        }

   
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
                    //await _signInManager.SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("Index", "Home");
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);

                    var emailMessage = $"<p>Welcome to the Game Store {model.FirstName}! Please confirm your email by clicking <a href='{HtmlEncoder.Default.Encode(confirmationLink)}'>here</a>.</p>";
                    await _emailService.SendEmailAsync(user.Email, "Confirm Your Registration", emailMessage);
                    return RedirectToAction("RegistrationConfirmationMessage");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
        public IActionResult RegistrationConfirmationMessage()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Error", "Home");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return RedirectToAction("ConfirmationSuccess");
            }

            return RedirectToAction("Error", "Home");
        }
        public IActionResult ConfirmationSuccess()
        {
            return View();
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
                    if(!await _userManager.IsEmailConfirmedAsync(user) && user.FirstName != "Admin")
                    {
                        ModelState.AddModelError(String.Empty, "You must confirm your email before you can log in.");
                        return View(model);
                    }
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
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
