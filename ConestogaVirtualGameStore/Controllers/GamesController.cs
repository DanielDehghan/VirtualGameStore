using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.ViewModels;
using ConestogaVirtualGameStore.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using ConestogaVirtualGameStore.AppDbContext;
using System.Collections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using MimeKit;

namespace ConestogaVirtualGameStore.Controllers
{
    public class GamesController : Controller
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly VirtualGameStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GamesController(VirtualGameStoreContext cvgs, IRepository<Game> gameRepository, UserManager<ApplicationUser> userManager)
        {
            _context = cvgs;
            _gameRepository = gameRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameRepository.GetAllAsync();
            return View(games);
        }

        public async Task<IActionResult> Games()
        {
            var games = await _gameRepository.GetAllAsync();
            return View(games);
        }

        [HttpGet]
        public IActionResult AddGame()
        {
            var model = new CreateGameViewModel
            {
                Genres = GetGenres(),
                Platforms = GetPlatforms()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(CreateGameViewModel model)
        {
            ModelState.Remove("Genres");
            ModelState.Remove("Platforms");
            if (ModelState.IsValid)
            {
                var game = new Game
                {
                    Title = model.Title,
                    Genere = model.SelectedGenere,
                    ReleaseDate = model.ReleaseDate,
                    Description = model.Description,
                    Platform = model.SelectedPlatform,
                    Price = model.Price,
                    CoverImageURL = model.CoverImageURL
                };

                await _gameRepository.AddAsync(game);
                return RedirectToAction("Games");
            }

            model.Genres = GetGenres();
            model.Platforms = GetPlatforms();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditGame(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            // Convert Game object to CreateGameViewModel
            var model = new CreateGameViewModel
            {
                Title = game.Title,
                SelectedGenere = game.Genere,
                ReleaseDate = game.ReleaseDate,
                Description = game.Description,
                SelectedPlatform = game.Platform,
                Price = game.Price,
                CoverImageURL = game.CoverImageURL,
                Genres = GetGenres(),
                Platforms = GetPlatforms()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditGame(CreateGameViewModel model, int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            ModelState.Remove("Genres");
            ModelState.Remove("Platforms");

            if (ModelState.IsValid)
            {
                // Update the existing game object rather than creating a new one
                game.Title = model.Title;
                game.Genere = model.SelectedGenere;
                game.ReleaseDate = model.ReleaseDate;
                game.Description = model.Description;
                game.Platform = model.SelectedPlatform;
                game.Price = model.Price;
                game.CoverImageURL = model.CoverImageURL;

                await _gameRepository.UpdateAsync(game);
                return RedirectToAction("Games");
            }

            // Repopulate the Genres and platforms if model state is invalid
            model.Genres = GetGenres();
            model.Platforms = GetPlatforms();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost, ActionName("DeleteGame")]
        public async Task<IActionResult> ConfirmDeleteGame(int id)
        {
            await _gameRepository.DeleteAsync(id);
            return RedirectToAction("Games");
        }

        public async Task<IActionResult> GameDetail(int id)
        {
            var game = await _gameRepository.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            // Get currently selected game recommendations based on the games genre
            var gameRecommendations = GetGameRecommendations(game.Title, game.Genere);

            int currentMemberId = await GetCurrentMemberId();

            var findCurrentGameIfBought = await _context.Orders
                .Where(o => o.Member_ID == currentMemberId && o.Status == "Processed" && o.Games.Contains(game))
                .FirstOrDefaultAsync();

            bool isBought;

            if (findCurrentGameIfBought == null) {
                isBought = false;
            }
            else
            {
                isBought = true;
            }
            
            var gameDetails = new GameDetailViewModel
            {
                Title = game.Title,
                Game = game,
                GameRecommendations = gameRecommendations,
                IsBought = isBought
            };

            return View(gameDetails);
        }

        public async Task<IActionResult> DownloadGame(int gameId)
        {
            var game = await _gameRepository.GetByIdAsync(gameId);

            string mimeType = "text/plain";
            string fileExtension = "txt";
            string name = game.Title;
            string fileName = $"{name}.{fileExtension}";

            string fileData = $"Genre: {game.Genere}\nRelease Date: {game.ReleaseDate}\nDescription: {game.Description}\nPlatforms: {game.Platform}\nPrice: {game.Price}";

            byte[] data = Encoding.UTF8.GetBytes(fileData);

            return File(data, mimeType, fileName);
        }

        [HttpGet]
        public async Task<JsonResult> SearchGames(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Json(new { success = false, results = new List<object>() });
            }

            var allGames = await _gameRepository.GetAllAsync();
            var matchingGames = allGames
                .Where(g => g.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            g.Genere.Contains(query, StringComparison.OrdinalIgnoreCase))
                .Select(g => new { g.GameId, g.Title, g.Genere })
                .Take(5)
                .ToList();

            return Json(new { success = true, results = matchingGames });
        }

        [HttpGet]
        public async Task<ActionResult> Genre(string Genere)
        {
            if (string.IsNullOrWhiteSpace(Genere))
            {
                return RedirectToAction("Index", "Home");
            }

            var games = await _gameRepository.GetAllAsync();
            var matchingGames = games
                .Where(g => g.Genere != null & g.Genere.Contains(Genere, StringComparison.OrdinalIgnoreCase))   
                .ToList();

            return View("Index", matchingGames);
        }

        private IEnumerable<Game> GetGameRecommendations(string title, string genre) 
        {
            var gameRecommendations = _context.Games
                .Where(g => g.Genere.Equals(genre) && g.Title != title)
                .Take(4)
                .ToList();

            return gameRecommendations;
        }

        private async Task<int> GetCurrentMemberId()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);

                var currentMemberId = await _context.Members
                    .Where(m => m.Email == user.Email)
                    .Select(m => m.Member_ID)
                    .FirstOrDefaultAsync();

                return currentMemberId;
            }

            return -1;
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

        private IEnumerable<SelectListItem> GetPlatforms()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "PC", Text = "PC" },
                new SelectListItem { Value = "PlayStation", Text = "PlayStation" },
                new SelectListItem { Value = "Xbox", Text = "Xbox" },
                new SelectListItem { Value = "Switch", Text = "Switch" }
            };
        }
    }
}