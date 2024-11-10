using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.Repository;
using ConestogaVirtualGameStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConestogaVirtualGameStore.AppDbContext;

namespace ConestogaVirtualGameStore.Controllers
{
    public class WishlistsController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<Wishlist> _wishlistRepository;
        private readonly IRepository<Wishlist_Games> _wishlistGamesRepository;
        private readonly VirtualGameStoreContext _context;

        public WishlistsController(VirtualGameStoreContext cvgs, IRepository<Wishlist> wishlistRepository, IRepository<Wishlist_Games> wishlistGamesRepository, UserManager<ApplicationUser> userManager)
        {
            _context = cvgs;
            _wishlistRepository = wishlistRepository;
            _wishlistGamesRepository = wishlistGamesRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Wishlists()
        {
            int currentMemberId = await GetCurrentMemberId();

            var wishlists = await _context.Wishlist
                .Where(w => w.Member_ID == currentMemberId)
                .ToListAsync();

            return View(wishlists);
        }

        [HttpGet]
        public async Task<IActionResult> AddWishlist()
        {
            int currentMemberId = await GetCurrentMemberId();
            var model = new CreateWishlistViewModel
            {
                Member_ID = currentMemberId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddWishlist(CreateWishlistViewModel model)
        {
            if (ModelState.IsValid)
            {
                var wishlist = new Wishlist
                {
                    Wishlist_Name = model.Wishlist_Name,
                    Member_ID = model.Member_ID
                };

                await _wishlistRepository.AddAsync(wishlist);
                return RedirectToAction("Wishlists");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditWishlist(int id)
        {
            var Wishlist = await _wishlistRepository.GetByIdAsync(id);
            if (Wishlist == null)
            {
                return NotFound();
            }

            var model = new CreateWishlistViewModel
            {
                Wishlist_Name = Wishlist.Wishlist_Name,
                Member_ID = Wishlist.Member_ID
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditWishlist(CreateWishlistViewModel model, int id)
        {
            var Wishlist = await _wishlistRepository.GetByIdAsync(id);
            if (Wishlist == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Wishlist.Wishlist_Name = model.Wishlist_Name;
                Wishlist.Member_ID = model.Member_ID;

                await _wishlistRepository.UpdateAsync(Wishlist);
                return RedirectToAction("Wishlists");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            int currentMemberId = await GetCurrentMemberId();

            var memberWishlistId = await _context.Wishlist
                .Where(wg => wg.Wishlist_ID == id && wg.Member_ID == currentMemberId)
                .Select(wg => wg.Wishlist_ID)
                .FirstOrDefaultAsync();

            await _wishlistRepository.DeleteAsync(memberWishlistId);

            return RedirectToAction("Wishlists");
        }
        [HttpGet]
        public async Task<IActionResult> WishlistDetail(int id)
        {
            var wishlist = await _context.Wishlist
                .Where(w => w.Wishlist_ID == id)
                .Include(w => w.Wishlist_Games)
                    .ThenInclude(wg => wg.Game)
                .FirstOrDefaultAsync();

            if (wishlist == null)
            {
                return NotFound();
            }

            var viewModel = new WishlistGamesViewModel
            {
                Wishlist = wishlist,
                GamesWishlist = wishlist.Wishlist_Games.Select(wg => wg.Game).ToList()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> RemoveGameFromWishlist(int wishlistId, int gameId)
        {
            var wishlistGame = await _context.Wishlist_Games
                .FirstOrDefaultAsync(wg => wg.Wishlist_ID == wishlistId && wg.GameId == gameId);

            if (wishlistGame == null)
            {
                return NotFound();
            }

            _context.Wishlist_Games.Remove(wishlistGame);
            await _context.SaveChangesAsync(); 

            return RedirectToAction("WishlistDetail", new { id = wishlistId });
        }

        public async Task<IActionResult> WishlistToBeAdded(int gameId)
        {
            var game = await _context.Games.FindAsync(gameId);

            if (game == null)
            {
                return NotFound();
            }

            int currentMemberId = await GetCurrentMemberId();
            var wishlists = await _context.Wishlist
                .Where(w => w.Member_ID == currentMemberId) 
                .ToListAsync();

            var viewModel = new WishlistGamesViewModel
            {
                Game = game,
                Wishlists = wishlists
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> WishlistToBeAdded(int gameId, int? wishlistId, string newWishlistName)
        {
            var game = await _context.Games.FindAsync(gameId);
            int currentMemberId = await GetCurrentMemberId();

            if (game == null)
            {
                return NotFound();
            }

            if (wishlistId.HasValue)
            {
                var existingEntry = await _context.Wishlist_Games
                    .FirstOrDefaultAsync(wg => wg.GameId == gameId && wg.Wishlist_ID == wishlistId.Value);

                if (existingEntry == null) 
                {
                    var wishlistGame = new Wishlist_Games
                    {
                        GameId = gameId,
                        Wishlist_ID = wishlistId.Value
                    };

                    _context.Wishlist_Games.Add(wishlistGame);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("WishlistDetail", new { id = wishlistId.Value });
            }
            else if (!string.IsNullOrEmpty(newWishlistName))
            {
                var newWishlist = new Wishlist
                {
                    Wishlist_Name = newWishlistName,
                    Member_ID = currentMemberId
                };

                _context.Wishlist.Add(newWishlist);
                await _context.SaveChangesAsync();

                var wishlistGame = new Wishlist_Games
                {
                    GameId = gameId,
                    Wishlist_ID = newWishlist.Wishlist_ID
                };

                _context.Wishlist_Games.Add(wishlistGame);
                await _context.SaveChangesAsync();

                return RedirectToAction("WishlistDetail", new { id = newWishlist.Wishlist_ID });
            }

            return RedirectToAction("WishlistDetail");
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

        public IActionResult Index()
        {
            return View();
        }
    }
}
