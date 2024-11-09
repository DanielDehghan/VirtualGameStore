using Microsoft.AspNetCore.Mvc;
using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.ViewModels;
using ConestogaVirtualGameStore.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConestogaVirtualGameStore.Controllers
{
    public class MemberController : Controller
    {
        private readonly IRepository<Member> _memberRepository;

        public MemberController(IRepository<Member> memberRepository)
        {
            _memberRepository = memberRepository;
        }


        // GET: Member/Members
        public async Task<IActionResult> Members()
        {
            var members = await _memberRepository.GetAllAsync();
            return View(members);
        }

        // GET: Member/AddGame
        [HttpGet]
        public IActionResult AddMember()
        {
            var model = new CreateMemberViewModel
            {
                PreferredCategories = GetGenres(),
                PreferredPlatforms = GetPlatforms()
            };

            return View(model);
        }

        // POST: Member/AddGame
        [HttpPost]
        public async Task<IActionResult> AddGame(CreateMemberViewModel model)
        {
            ModelState.Remove("DeliveryInstruction");
            ModelState.Remove("Platforms");

            if (ModelState.IsValid)
            {
                var member = new Member
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone_Number = model.Phone_Number,
                    Password = model.Password,
                    PreferredLanguage = model.PreferredLanguage,
                    PreferredPlatform = model.PreferredPlatform,
                    PreferredCategory = model.PreferredCategory,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth,
                    Apt_suit = model.Apt_suit,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    Province = model.Province,
                    Country = model.Country,
                    Postal_Code = model.Postal_Code,
                };

                await _memberRepository.AddAsync(member);
                return RedirectToAction("Games");
            }

            model.PreferredCategories = GetGenres();
            model.PreferredPlatforms = GetPlatforms();
            return View(model);
        }

        // GET: Member/EditMember/5
        [HttpGet]
        public async Task<IActionResult> EditMember(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            var model = new CreateMemberViewModel
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                Phone_Number = member.Phone_Number,
                Password = member.Password,
                PreferredLanguage = member.PreferredLanguage,
                PreferredPlatform = member.PreferredPlatform,
                PreferredCategory = member.PreferredCategory,
                Gender = member.Gender,
                DateOfBirth = member.DateOfBirth,
                Apt_suit = member.Apt_suit,
                StreetAddress = member.StreetAddress,
                City = member.City,
                Province = member.Province,
                Country = member.Country,
                Postal_Code = member.Postal_Code,
                PreferredCategories = GetGenres(),
                PreferredPlatforms = GetPlatforms()
            };

            return View(model);
        }

        // POST: Member/EditMember/5
        [HttpPost]
        public async Task<IActionResult> EditMember(CreateMemberViewModel model, int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            ModelState.Remove("Genres");
            ModelState.Remove("Platforms");

            if (ModelState.IsValid)
            {
                member.FirstName = model.FirstName;
                member.LastName = model.LastName;
                member.Email = model.Email;
                member.Phone_Number = model.Phone_Number;
                member.Password = model.Password;
                member.PreferredLanguage = model.PreferredLanguage;
                member.PreferredPlatform = model.PreferredPlatform;
                member.PreferredCategory = model.PreferredCategory;
                member.Gender = model.Gender;
                member.DateOfBirth = model.DateOfBirth;
                member.Apt_suit = model.Apt_suit;
                member.StreetAddress = model.StreetAddress;
                member.City = model.City;
                member.Province = model.Province;
                member.Country = model.Country;
                member.Postal_Code = model.Postal_Code;

                await _memberRepository.UpdateAsync(member);
                return RedirectToAction("Members");
            }

            model.PreferredCategories = GetGenres();
            model.PreferredPlatforms = GetPlatforms();
            return View(model);
        }

        // GET: Member/DeleteMember/5
        [HttpGet]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
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
