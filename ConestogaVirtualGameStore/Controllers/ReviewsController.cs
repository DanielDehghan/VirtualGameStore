using ConestogaVirtualGameStore.AppDbContext;
using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConestogaVirtualGameStore.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IRepository<Review> _reviewsRepository;
        private readonly VirtualGameStoreContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReviewsController(VirtualGameStoreContext cvgs, IRepository<Review> reviewsRepository, UserManager<ApplicationUser> userManager)
        {
            _context = cvgs;
            _reviewsRepository = reviewsRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> ManageReviews()
        {
            int currentMemberId = await GetCurrentMemberId();

            var orders = await _context.Reviews
                .Where(r => r.Status == "Processing")
                .Include(r => r.Member)
                .ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> ApproveReview(int id)
        {
            var approvedReview = await _context.Reviews.FindAsync(id);

            approvedReview.Status = "Processed";

            await _reviewsRepository.UpdateAsync(approvedReview);

            return RedirectToAction("ManageReviews");
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
