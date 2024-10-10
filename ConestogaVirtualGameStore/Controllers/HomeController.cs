using ConestogaVirtualGameStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyVirtualGameStore.AppDbContext;
using System;
using System.Diagnostics;

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
	}
}
