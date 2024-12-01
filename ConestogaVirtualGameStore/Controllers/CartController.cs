using ConestogaVirtualGameStore.AppDbContext;
using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.Repository;
using ConestogaVirtualGameStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ConestogaVirtualGameStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository<Cart> _cartRespository;
        private readonly IRepository<CartGames> _cartGamesRespository;
        private readonly VirtualGameStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<Game> _gameRepository;

        public CartController(VirtualGameStoreContext cvgs, IRepository<Cart> cartRepository, IRepository<CartGames> cartGamesRepository, UserManager<ApplicationUser> userManager, IRepository<Game> gamesRepository) 
        {
            _context = cvgs;
            _cartRespository = cartRepository;
            _cartGamesRespository = cartGamesRepository;
            _userManager = userManager;
            _gameRepository = gamesRepository;
        }

        public async Task<IActionResult> Cart()
        {
            int currentMemberId = await GetCurrentMemberId();
            int currentCartId = await GetCurrentCartId(currentMemberId);

            var cartGames = await _context.CartGames
                .Where(cg => cg.Cart_ID.Equals(currentCartId))
                .Include(cg => cg.Game)
                .ToListAsync();

            return View(cartGames);
        }

        public async Task<IActionResult> AddGameToCart(int gameId) 
        {
            int currentMemberId = await GetCurrentMemberId();

            // check to see if a cart is created already for the user
            // if not create one
            var cart = await _context.Carts
                .Where(c => c.Member_ID == currentMemberId)
                .FirstOrDefaultAsync();

            if (cart == null) 
            {
                var newCart = new Cart
                {
                    Member_ID = currentMemberId,  
                    Date_Created = DateTime.Now
                };

                await _context.Carts.AddAsync(newCart);
                await _context.SaveChangesAsync();

                // find cart again if user didnt have a cart before
                cart = await _context.Carts
                    .Where(c => c.Member_ID == currentMemberId)
                    .FirstOrDefaultAsync();
            }

            var game = await _gameRepository.GetByIdAsync(gameId);

            var existingEntry = await _context.CartGames
                    .FirstOrDefaultAsync(cg => cg.Game_ID == gameId && cg.CartGames_ID == cart.Cart_ID);

            if (existingEntry == null)
            {
                var newCartGame = new CartGames
                {
                    Cart_ID = cart.Cart_ID,
                    Game_ID = game.GameId,
                    Quantity = 1,
                    Total = game.Price
                };

                await _context.CartGames.AddAsync(newCartGame);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Cart");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            int currentMemberId = await GetCurrentMemberId();
            int currentCartId = await GetCurrentCartId(currentMemberId);

            var memberCartGameId = await _context.CartGames
                .Where(cg => cg.Cart_ID.Equals(currentCartId) && cg.Game_ID == id)
                .FirstOrDefaultAsync();

            _context.CartGames.Remove(memberCartGameId);
            await _context.SaveChangesAsync();

            return RedirectToAction("Cart");
        }

        [HttpGet]
        public async Task<IActionResult> CheckOut() 
        {
            int currentMemberId = await GetCurrentMemberId();
            int currentCartId = await GetCurrentCartId(currentMemberId);

            var cartValue = await _context.CartGames
                .Where(cg => cg.Cart_ID.Equals(currentCartId))
                .Select(cg => cg.Game.Price)
                .ToListAsync();

            decimal subTotal = cartValue.Sum();
            decimal tax = subTotal * 0.13m;

            decimal total = subTotal + tax;
            decimal totalRounded = Math.Round(total, 2);

            var creditCards = await _context.CreditCards
                .Where(w => w.Member_ID == currentMemberId)
                .ToListAsync();

            var model = new CheckOutViewModel
            {
                Total = totalRounded,
                CreditCards = creditCards
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOutItems() 
        {
            int currentMemberId = await GetCurrentMemberId();
            int currentCartId = await GetCurrentCartId(currentMemberId);

            var cartGames = await _context.CartGames
                .Where(cg => cg.Cart_ID.Equals(currentCartId))
                .Select(cg => cg.Game)
                .ToListAsync();

            var cartValue = await _context.CartGames
                .Where(cg => cg.Cart_ID.Equals(currentCartId))
                .Select(cg => cg.Game.Price)
                .ToListAsync();

            decimal subTotal = cartValue.Sum();
            decimal tax = subTotal * 0.13m;

            decimal total = subTotal + tax;


            var newOrder = new Orders
            {
                Member_ID = currentMemberId,
                Status = "Processing",
                Games = cartGames,
                TotalPrice = total
            };

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            var oldCart = await _context.Carts
                .Where(cg => cg.Cart_ID.Equals(currentCartId))
                .FirstOrDefaultAsync();

            _context.Carts.Remove(oldCart);
            await _context.SaveChangesAsync();

            return RedirectToAction("Orders", "Orders");
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

        private async Task<int> GetCurrentCartId(int memberId)
        {
            var currentCartId = await _context.Carts
                .Where(c => c.Member_ID == memberId)
                .Select(c => c.Cart_ID)
                .FirstOrDefaultAsync();

            return currentCartId;
        }

        public async Task<JsonResult> GetCartQuantity() 
        {
            int currentMemberId = await GetCurrentMemberId();
            var cartQuantity = await _context.CartGames
                .Where(cg => cg.Cart.Member_ID == currentMemberId)
                .Select(cg => cg.Game)
                .ToListAsync();

            return Json(new { success = true, results =  cartQuantity.Count()});
        }
    }
}
