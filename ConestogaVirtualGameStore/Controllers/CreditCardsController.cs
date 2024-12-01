using ConestogaVirtualGameStore.AppDbContext;
using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.Repository;
using ConestogaVirtualGameStore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConestogaVirtualGameStore.Controllers
{
    public class CreditCardsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<CreditCards> _creditCardRepository;
        private readonly VirtualGameStoreContext _context;

        public CreditCardsController(VirtualGameStoreContext cvgs, IRepository<CreditCards> creditCardRepository, UserManager<ApplicationUser> userManager)
        {
            _context = cvgs;
            _creditCardRepository = creditCardRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> CreditCards()
        {
            int currentMemberId = await GetCurrentMemberId();

            var creditCards = await _context.CreditCards
                .Where(w => w.Member_ID == currentMemberId)
                .ToListAsync();

            return View(creditCards);
        }

        [HttpGet]
        public async Task<IActionResult> AddCreditCard()
        {
            int currentMemberId = await GetCurrentMemberId();
            var model = new CreateCreditCardViewModel
            {
                Member_ID = currentMemberId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCreditCard(CreateCreditCardViewModel model)
        {
            if (ModelState.IsValid)
            {
                var creditCard = new CreditCards
                {
                    CreditCardNumber = model.CreditCardNumber,
                    CreditCardOwnerName = model.CreditCardOwnerName,
                    CreditCardExpiryDate = model.CreditCardExpiryDate,
                    CreditCardVerificationValue = model.CreditCardVerificationValue,
                    Member_ID = model.Member_ID
                };

                await _creditCardRepository.AddAsync(creditCard);
                return RedirectToAction("CreditCards");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditCreditCard(int id)
        {
            var creditCard = await _creditCardRepository.GetByIdAsync(id);
            if (creditCard == null)
            {
                return NotFound();
            }

            var model = new CreateCreditCardViewModel
            {
                CreditCardNumber = creditCard.CreditCardNumber,
                CreditCardOwnerName = creditCard.CreditCardOwnerName,
                CreditCardExpiryDate = creditCard.CreditCardExpiryDate,
                CreditCardVerificationValue = creditCard.CreditCardVerificationValue,
                Member_ID = creditCard.Member_ID
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCreditCard(CreateCreditCardViewModel model, int id)
        {
            var creditCard = await _creditCardRepository.GetByIdAsync(id);
            if (creditCard == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                creditCard.CreditCardNumber = model.CreditCardNumber;
                creditCard.CreditCardOwnerName = model.CreditCardOwnerName;
                creditCard.CreditCardExpiryDate = model.CreditCardExpiryDate;
                creditCard.CreditCardVerificationValue = model.CreditCardVerificationValue;
                creditCard.Member_ID = model.Member_ID;

                await _creditCardRepository.UpdateAsync(creditCard);
                return RedirectToAction("CreditCards");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCreditCard(int id)
        {
            int currentMemberId = await GetCurrentMemberId();

            var memberCreditCardId = await _context.CreditCards
                .Where(cc => cc.CreditCard_ID == id && cc.Member_ID == currentMemberId)
                .Select(wg => wg.CreditCard_ID)
                .FirstOrDefaultAsync();

            await _creditCardRepository.DeleteAsync(memberCreditCardId);

            return RedirectToAction("CreditCards");
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
