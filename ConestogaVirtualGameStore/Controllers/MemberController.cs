using Microsoft.AspNetCore.Mvc;
using ConestogaVirtualGameStore.Models;
using System.Linq;
using ConestogaVirtualGameStore.AppDbContext;
using Microsoft.EntityFrameworkCore;
using ConestogaVirtualGameStore.ViewModels;
using ConestogaVirtualGameStore.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace ConestogaVirtualGameStore.Controllers
{
    public class MemberController : Controller
    {
        private readonly IRepository<Member> _memberRepository;
        private readonly VirtualGameStoreContext _context;

        public MemberController(IRepository<Member> memberRepository, VirtualGameStoreContext context)
        {
            _memberRepository = memberRepository;
            _context = context;
        }

        public async Task<IActionResult> PersonalInfo()
        {
            var user = await _context.Members.FirstOrDefaultAsync(m => m.Email == User.Identity.Name);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePersonalInfo(Member member)
        {
            ModelState.Remove("PreferredPlatforms");
            ModelState.Remove("PreferredCategories");
            ModelState.Remove("PreferredLanguages");
            ModelState.Remove("Countries");
            ModelState.Remove("Email");
            ModelState.Remove("Register_Date ");
            ModelState.Remove("Password");
            ModelState.Remove("Apt_suit");
            ModelState.Remove("StreetAddress");
            ModelState.Remove("City");
            ModelState.Remove("Province");
            ModelState.Remove("Country ");
            ModelState.Remove("Postal_Code");
            ModelState.Remove("DeliveryInstruction");
            ModelState.Remove("MemberRelationshipPrimary");
            ModelState.Remove("MemberRelationshipRelated");
            ModelState.Remove("Wishlists");
            ModelState.Remove("Cart");
            ModelState.Remove("Orders");
            ModelState.Remove("CreditCards");
            ModelState.Remove("Reviews");

            if (ModelState.IsValid)
            {
                var user = await _context.Members.FirstOrDefaultAsync(m => m.Email == User.Identity.Name);

                if (user != null)
                {
                    // Personal Information Fields
                    user.FirstName = member.FirstName;
                    user.LastName = member.LastName;
                    user.Phone_Number = member.Phone_Number;
                    user.DateOfBirth = member.DateOfBirth;
                    user.Gender = member.Gender;


                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("PersonalInfo");
            }
            return View("PersonalInfo", member);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAddressInfo(Member member)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("Phone_Number");
            ModelState.Remove("Email");
            ModelState.Remove("DateOfBirth");
            ModelState.Remove("Gender ");
            ModelState.Remove("DeliveryInstruction");
            ModelState.Remove("PreferredPlatforms");
            ModelState.Remove("PreferredCategories");
            ModelState.Remove("PreferredLanguages");
            ModelState.Remove("Countries");
            ModelState.Remove("Register_Date ");
            ModelState.Remove("Password");
            ModelState.Remove("MemberRelationshipPrimary");
            ModelState.Remove("MemberRelationshipRelated");
            ModelState.Remove("Wishlists");
            ModelState.Remove("Cart");
            ModelState.Remove("Orders");
            ModelState.Remove("CreditCards");
            ModelState.Remove("Reviews");

            if (ModelState.IsValid)
            {
                var user = await _context.Members.FirstOrDefaultAsync(m => m.Email == User.Identity.Name);

                if (user != null)
                {

                    // Address Fields
                    user.Apt_suit = member.Apt_suit;
                    user.StreetAddress = member.StreetAddress;
                    user.City = member.City;
                    user.Province = member.Province;
                    user.Country = member.Country;
                    user.Postal_Code = member.Postal_Code;
                    user.DeliveryInstruction = member.DeliveryInstruction;

                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("PersonalInfo");
            }
            return View("PersonalInfo", member);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAddress()
        {
            var user = await _context.Members.FirstOrDefaultAsync(m => m.Email == User.Identity.Name);

            if (user != null)
            {
                user.Apt_suit = null;
                user.StreetAddress = null;
                user.City = null;
                user.Province = null;
                user.Country = null;
                user.Postal_Code = null;
                user.DeliveryInstruction = null;

                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("PersonalInfo");
        }

        public async Task<IActionResult> Preferences()
        {
            var user = await _context.Members
                .FirstOrDefaultAsync(m => m.Email == User.Identity.Name);

            if (user == null)
            {
                return NotFound();
            }

            var model = new CreateMemberViewModel
            {
                PreferredLanguage = user.PreferredLanguage,
                PreferredPlatform = user.PreferredPlatform,
                PreferredCategory = user.PreferredCategory,
                PreferredLanguages = GetLanguageSelectList(),
                PreferredPlatforms = GetPlatforms(),
                PreferredCategories = GetGenres()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePreferences(CreateMemberViewModel model)
        {
            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");
            ModelState.Remove("Phone_Number");
            ModelState.Remove("Email");
            ModelState.Remove("DateOfBirth");
            ModelState.Remove("Gender ");
            ModelState.Remove("Countries");
            ModelState.Remove("Register_Date ");
            ModelState.Remove("Password");
            ModelState.Remove("Apt_suit");
            ModelState.Remove("StreetAddress");
            ModelState.Remove("City");
            ModelState.Remove("Province");
            ModelState.Remove("Country ");
            ModelState.Remove("Postal_Code");
            ModelState.Remove("DeliveryInstruction");
            ModelState.Remove("PreferredPlatforms");
            ModelState.Remove("PreferredCategories");
            ModelState.Remove("PreferredLanguages");

            if (ModelState.IsValid)
            {
                var user = await _context.Members.FirstOrDefaultAsync(m => m.Email == User.Identity.Name);

                if (user != null)
                {
                    user.PreferredLanguage = model.PreferredLanguage;
                    user.PreferredPlatform = model.PreferredPlatform;
                    user.PreferredCategory = model.PreferredCategory;

                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Preferences");
            }

            // Repopulate dropdowns in case of validation error
            model.PreferredLanguages = GetLanguageSelectList();
            model.PreferredPlatforms = GetPlatforms();
            model.PreferredCategories = GetGenres();
            return View("Preferences", model);
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
                PreferredPlatforms = GetPlatforms(),
                PreferredLanguages = GetLanguageSelectList(),
                Countries = GetAllCountries()
            };

            return View(model);

        }

        // POST: Member/AddGame
        [HttpPost]
        public async Task<IActionResult> AddMember(CreateMemberViewModel model)
        {
            ModelState.Remove("DeliveryInstruction");
            ModelState.Remove("ReceivePromotionalEmails");
            ModelState.Remove("Register_Date");
            ModelState.Remove("PreferredLanguages");
            ModelState.Remove("PreferredPlatforms");
            ModelState.Remove("PreferredCategories");
            ModelState.Remove("Countries");
            ModelState.Remove("Register_Date ");
            ModelState.Remove("Password");
            ModelState.Remove("Wishlists");
            ModelState.Remove("MemberRelationshipPrimary");
            ModelState.Remove("MemberRelationshipRelated");


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
                return RedirectToAction("Members");
            }

            model.PreferredCategories = GetGenres();
            model.PreferredPlatforms = GetPlatforms();
            model.PreferredLanguages = GetLanguageSelectList();
            model.Countries = GetAllCountries();
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
                PreferredPlatforms = GetPlatforms(),
                PreferredLanguages = GetLanguageSelectList(),
                Countries = GetAllCountries()
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

            ModelState.Remove("DeliveryInstruction");
            ModelState.Remove("ReceivePromotionalEmails");
            ModelState.Remove("Register_Date");
            ModelState.Remove("PreferredLanguages");
            ModelState.Remove("PreferredPlatforms");
            ModelState.Remove("PreferredCategories");
            ModelState.Remove("PreferredLanguages");
            ModelState.Remove("Wishlists");
            ModelState.Remove("MemberRelationshipPrimary");
            ModelState.Remove("MemberRelationshipRelated");
            ModelState.Remove("Countries");
            if (string.IsNullOrEmpty(model.Password))
            {
                model.Password = member.Password;
            }

 
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
            model.PreferredLanguages = GetLanguageSelectList();
            model.Countries = GetAllCountries();
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

        [HttpPost, ActionName("DeleteMember")]
        public async Task<IActionResult> ConfirmDeleteMember(int id)
        {
            await _memberRepository.DeleteAsync(id);
            return RedirectToAction("Members");
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

        private IEnumerable<SelectListItem> GetLanguageSelectList()
        {
            var languages = new List<string>
            {
                "English", "Spanish", "French", "German", "Chinese", "Japanese", "Korean",
                "Russian", "Arabic", "Portuguese", "Hindi", "Bengali", "Italian", "Dutch",
                "Turkish", "Swedish", "Norwegian", "Danish", "Finnish", "Polish", "Greek",
                "Hebrew", "Thai", "Vietnamese", "Indonesian", "Malay", "Persian", "Czech",
                "Hungarian", "Romanian", "Ukrainian", "Bulgarian", "Croatian", "Serbian",
                "Slovak", "Slovenian", "Icelandic", "Latvian", "Lithuanian", "Estonian"
            };

            return languages.Select(lang => new SelectListItem { Value = lang, Text = lang });
        }

        private IEnumerable<SelectListItem> GetAllCountries()
        {
            var countries = new List<string>
            {
                "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda",
                "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain",
                "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia",
                "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso",
                "Burundi", "Cabo Verde", "Cambodia", "Cameroon", "Canada", "Central African Republic",
                "Chad", "Chile", "China", "Colombia", "Comoros", "Congo", "Costa Rica", "Croatia",
                "Cuba", "Cyprus", "Czech Republic", "Democratic Republic of the Congo", "Denmark",
                "Djibouti", "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea",
                "Eritrea", "Estonia", "Eswatini", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia",
                "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau",
                "Guyana", "Haiti", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq",
                "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati",
                "Korea, North", "Korea, South", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho",
                "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar", "Malawi",
                "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius",
                "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique",
                "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger",
                "Nigeria", "North Macedonia", "Norway", "Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea",
                "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda",
                "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino",
                "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone",
                "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Sudan",
                "Spain", "Sri Lanka", "Sudan", "Suriname", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan",
                "Tanzania", "Thailand", "Timor-Leste", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia",
                "Turkey", "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom",
                "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City", "Venezuela", "Vietnam",
                "Yemen", "Zambia", "Zimbabwe"
            };
            countries.Sort();

            return countries.Select(country => new SelectListItem { Value = country, Text = country });
        }

    }
}
