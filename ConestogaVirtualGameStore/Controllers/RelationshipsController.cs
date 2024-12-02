using ConestogaVirtualGameStore.AppDbContext;
using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.Repository;
using ConestogaVirtualGameStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ConestogaVirtualGameStore.Controllers
{
    public class RelationshipsController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<MemberRelationship> _memberRelationshipRepository;
        private readonly VirtualGameStoreContext _context;

        public RelationshipsController(VirtualGameStoreContext cvgs, IRepository<Member> memberRepository, 
            IRepository<MemberRelationship> memberRelationshipRepository, UserManager<ApplicationUser> userManager)
        {
            _context = cvgs;
            _memberRepository = memberRepository;
            _memberRelationshipRepository = memberRelationshipRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Friends()
        {
            int currentMemberId = await GetCurrentMemberId();

            var friends = await _context.MembersRelationships
                .Where(f => f.Member_ID == currentMemberId && f.Relationship_ID == 1)
                .Include(f => f.MemberAdded) 
                .ToListAsync();

            return View(friends);
        }

        public async Task<IActionResult> Family()
        {
            int currentMemberId = await GetCurrentMemberId();

            var family = await _context.MembersRelationships
                .Where(f => f.Member_ID == currentMemberId && f.Relationship_ID == 2)
                .Include(f => f.MemberAdded) 
                .ToListAsync();

            return View(family);
        }

        public async Task<IActionResult> Friend(int friendId)
        {
            var friend = _context.Members
              .FirstOrDefault(f => f.Member_ID == friendId);

            var wishlists = await _context.Wishlist
                .Where(w => w.Member_ID == friendId)
                .ToListAsync();

            var model = new WishlistFriendFamilyViewModel
            {
                Member = friend,
                Wishlists = wishlists
            };

            return View(model);
        }

        public async Task<IActionResult> FamilyMember(int familyId)
        {
            var family = _context.Members
              .FirstOrDefault(f => f.Member_ID == familyId);

            var wishlists = await _context.Wishlist
                .Where(w => w.Member_ID == familyId)
                .ToListAsync();

            var model = new WishlistFriendFamilyViewModel
            {
                Member = family,
                Wishlists = wishlists
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> WishlistDetailFriendFamily(int id)
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

        public async Task<IActionResult> AddFriend()
        {
            int currentMemberId = await GetCurrentMemberId();

            var friends = await _context.Members
                .Where(m => m.Member_ID != currentMemberId)
                .Where(m => !_context.MembersRelationships
                .Any(r => r.Member_ID == currentMemberId && r.MemberAdded_ID == m.Member_ID))
                .ToListAsync();

            var model = new RelationshipViewModel
            {
                Members = friends
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFriend(int memberAddedId)
        {
            int currentMemberId = await GetCurrentMemberId();

            var newFriendship = new MemberRelationship
            {
                Member_ID = currentMemberId,
                MemberAdded_ID = memberAddedId,
                Relationship_ID = 1
            };

            _context.MembersRelationships.Add(newFriendship);
            await _context.SaveChangesAsync();

            var friends = await _context.MembersRelationships
                .Where(f => f.Member_ID == currentMemberId && f.Relationship_ID == 1)
                .Include(f => f.MemberAdded) 
                .ToListAsync();
            return RedirectToAction("Friends", friends);
        }

        public async Task<IActionResult> AddFamily()
        {
            int currentMemberId = await GetCurrentMemberId();

            var family = await _context.Members
                .Where(m => m.Member_ID != currentMemberId)
                .Where(m => !_context.MembersRelationships
                .Any(r => r.Member_ID == currentMemberId && r.MemberAdded_ID == m.Member_ID))
                .ToListAsync();

            var model = new RelationshipViewModel
            {
                Members = family
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFamily(int memberAddedId)
        {
            int currentMemberId = await GetCurrentMemberId();

            var newFamily = new MemberRelationship
            {
                Member_ID = currentMemberId,
                MemberAdded_ID = memberAddedId,
                Relationship_ID = 2
            };

            _context.MembersRelationships.Add(newFamily);
            await _context.SaveChangesAsync();

            var family = await _context.MembersRelationships
                .Where(f => f.Member_ID == currentMemberId && f.Relationship_ID == 2)
                .Include(f => f.MemberAdded)
                .ToListAsync();

            return RedirectToAction("Family", family);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFriend(int id)
        {
            var memberRelationship = await _memberRelationshipRepository.GetByIdAsync(id);
            if (memberRelationship == null)
            {
                return NotFound();
            }

            var memberAdded = await _memberRepository.GetByIdAsync(memberRelationship.MemberAdded_ID);
            memberRelationship.MemberAdded = memberAdded;

            return View(memberRelationship);
        }

        [HttpPost, ActionName("DeleteFriend")]
        public async Task<IActionResult> ConfirmDeleteFriend(int id)
        {
            await _memberRelationshipRepository.DeleteAsync(id);
            return RedirectToAction("Friends");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFamily(int id)
        {
            var memberRelationship = await _memberRelationshipRepository.GetByIdAsync(id);
            if (memberRelationship == null)
            {
                return NotFound();
            }

            var memberAdded = await _memberRepository.GetByIdAsync(memberRelationship.MemberAdded_ID);
            memberRelationship.MemberAdded = memberAdded;

            return View(memberRelationship);
        }

        [HttpPost, ActionName("DeleteFamily")]
        public async Task<IActionResult> ConfirmDeleteFamily(int id)
        {
            await _memberRelationshipRepository.DeleteAsync(id);
            return RedirectToAction("Family");
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
