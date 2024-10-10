using Microsoft.AspNetCore.Mvc;

namespace ConestogaVirtualGameStore.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
