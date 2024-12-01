using ConestogaVirtualGameStore.AppDbContext;
using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConestogaVirtualGameStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IRepository<Orders> _ordersRepository;
        private readonly VirtualGameStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<Game> _gameRepository;

        public OrdersController(VirtualGameStoreContext cvgs, IRepository<Orders> ordersRepository, UserManager<ApplicationUser> userManager, IRepository<Game> gamesRepository)
        {
            _context = cvgs;
            _ordersRepository = ordersRepository;
            _userManager = userManager;
            _gameRepository = gamesRepository;
        }

        public async Task<IActionResult> Orders()
        {
            int currentMemberId = await GetCurrentMemberId();

            var orders = await _context.Orders
                .Where(o => o.Member_ID.Equals(currentMemberId))
                .Include(o => o.Games)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> ManageOrders() 
        {
            int currentMemberId = await GetCurrentMemberId();

            var orders = await _context.Orders
                .Where(o => o.Status == "Processing")
                .Include(o => o.Games)
                .Include(o => o.Member)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> ApproveOrder(int id) 
        {
            var approvedOrder = await _ordersRepository.GetByIdAsync(id);

            approvedOrder.Status = "Processed";

            await _ordersRepository.UpdateAsync(approvedOrder);

            return RedirectToAction("ManageOrders");
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
    }
}
