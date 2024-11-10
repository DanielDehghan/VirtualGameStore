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

namespace ConestogaVirtualGameStore.Controllers
{
    public class GamesController : Controller
    {
        private readonly IRepository<Game> _gameRepository;
        private readonly VirtualGameStoreContext _context;

        public GamesController(VirtualGameStoreContext cvgs, IRepository<Game> gameRepository)
        {
            _context = cvgs;
            _gameRepository = gameRepository;
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
                Generes = GetGenres(),
                Platforms = GetPlatforms()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(CreateGameViewModel model)
        {
            ModelState.Remove("Generes");
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

            model.Generes = GetGenres();
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
                Generes = GetGenres(),
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

            ModelState.Remove("Generes");
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

            // Repopulate the Generes and platforms if model state is invalid
            model.Generes = GetGenres();
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

            var gameDetails = new GameDetailViewModel
            {
                Title = game.Title,
                Game = game,
                GameRecommendations = gameRecommendations
            };

            return View(gameDetails);
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
        public async Task<ActionResult> Genere(string Genere)
        {
            if (string.IsNullOrWhiteSpace(Genere))
            {
                return RedirectToAction("Index"); 
            }

            var games = await _gameRepository.GetAllAsync();
            var matchingGames = games
                .Where(g => g.Genere.Equals(Genere, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return View("GamesByGenere", matchingGames); 
        }

        private IEnumerable<Game> GetGameRecommendations(string title, string genre) 
        {
            var gameRecommendations = _context.Games
                .Where(g => g.Genere.Equals(genre) && g.Title != title)
                .Take(4)
                .ToList();

            return gameRecommendations;
        }

        private IEnumerable<SelectListItem> GetGenres()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Action", Text = "Action" },
                new SelectListItem { Value = "Adventure", Text = "Adventure" },
                new SelectListItem { Value = "RPG", Text = "RPG" },
                new SelectListItem { Value = "Strategy", Text = "Strategy" },
                new SelectListItem { Value = "Sports", Text = "Sports" }
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