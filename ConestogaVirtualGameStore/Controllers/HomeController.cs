using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConestogaVirtualGameStore.AppDbContext;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConestogaVirtualGameStore.Controllers
{
	public class HomeController : Controller
	{
        private readonly ILogger<HomeController> _logger;
        private readonly VirtualGameStoreContext _context;

        public HomeController(ILogger<HomeController> logger, VirtualGameStoreContext context)
        {
			_logger = logger; 
			_context = context;
        }
        public IActionResult Index()
		{
            ViewBag.ShowLeftSidebar = true;
            ViewBag.ShowRightSidebar = true;
            ViewBag.Genres = GetGenres() ?? new List<SelectListItem>();
            ViewBag.NewGames = _context.Games?.ToList() ?? new List<Game>();
            ViewBag.Events = _context.Events?.ToList() ?? new List<Event>();
            var games = _context.Games.ToList(); 
            return View(games);
        }

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

        private IEnumerable<SelectListItem> GetGenres()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Action", Text = "Action" },
                new SelectListItem { Value = "Adventure", Text = "Adventure" },
                new SelectListItem { Value = "RPG", Text = "RPG" },
                new SelectListItem { Value = "Strategy", Text = "Strategy" },
                new SelectListItem { Value = "Sports", Text = "Sports" },
                new SelectListItem { Value = "Horror", Text = "Horror" }

            };
        }
    }
}
