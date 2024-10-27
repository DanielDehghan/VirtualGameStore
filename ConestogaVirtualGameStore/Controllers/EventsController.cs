using ConestogaVirtualGameStore.Models;
using ConestogaVirtualGameStore.Repository;
using ConestogaVirtualGameStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConestogaVirtualGameStore.Controllers
{
    public class EventsController : Controller
    {
        private readonly IRepository<Event> _eventRepository;

        public EventsController(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventRepository.GetAllAsync();
            return View(events);
        }

        public async Task<IActionResult> Events()
        {
            var events = await _eventRepository.GetAllAsync();
            return View(events);
        }

        [HttpGet]
        public IActionResult AddEvent()
        {
            var model = new CreateEventViewModel
            {
                Provinces = GetProvinces()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvent(CreateEventViewModel model)
        {
            ModelState.Remove("Provinces");
            if (ModelState.IsValid)
            {
                var Event = new Event
                {
                    Name = model.Name,
                    Date = model.Date,
                    Address = model.Address,
                    Country = model.Country,
                    City = model.City,
                    Province = model.SelectedProvince,
                    PostalCode = model.PostalCode,
                    Description = model.Description
                };

                await _eventRepository.AddAsync(Event);
                return RedirectToAction("Events");
            }

            model.Provinces = GetProvinces();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditEvent(int id)
        {
            var Event = await _eventRepository.GetByIdAsync(id);
            if (Event == null)
            {
                return NotFound();
            }

            // Convert Event object to CreateEventViewModel
            var model = new CreateEventViewModel
            {
                Name = Event.Name,
                Date = Event.Date,
                Address = Event.Address,
                Country = Event.Country,
                City = Event.City,
                SelectedProvince = Event.Province,
                PostalCode = Event.PostalCode,
                Description = Event.Description,  
                Provinces = GetProvinces()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(CreateEventViewModel model, int id)
        {
            var Event = await _eventRepository.GetByIdAsync(id);
            if (Event == null)
            {
                return NotFound();
            }

            ModelState.Remove("Provinces");

            if (ModelState.IsValid)
            {
                // Update the existing event object rather than creating a new one
                Event.Name = model.Name;
                Event.Date = model.Date;
                Event.Address = model.Address;
                Event.Country = model.Country;
                Event.City = model.City;
                Event.Province = model.SelectedProvince;
                Event.PostalCode = model.PostalCode;
                Event.Description = model.Description;

                await _eventRepository.UpdateAsync(Event);
                return RedirectToAction("Events");
            }

            // Repopulate the provinces if model state is invalid
            model.Provinces = GetProvinces();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var Event = await _eventRepository.GetByIdAsync(id);
            if (Event == null)
            {
                return NotFound();
            }
            return View(Event);
        }

        [HttpPost, ActionName("DeleteEvent")]
        public async Task<IActionResult> ConfirmDeleteEvent(int id)
        {
            await _eventRepository.DeleteAsync(id);
            return RedirectToAction("Events");
        }

        public async Task<IActionResult> EventDetail(int id)
        {
            var Event = await _eventRepository.GetByIdAsync(id);
            if (Event == null)
            {
                return NotFound();
            }
            return View(Event);
        }

        private IEnumerable<SelectListItem> GetProvinces()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Ontario", Text = "Ontario" },
                new SelectListItem { Value = "Quebec", Text = "Quebec" },
                new SelectListItem { Value = "Alberta", Text = "Alberta" },
                new SelectListItem { Value = "British Columbia", Text = "British Columbia" },
                new SelectListItem { Value = "Saskatchewan", Text = "Saskatchewan" },
                new SelectListItem { Value = "Manitoba", Text = "Manitoba" },
                new SelectListItem { Value = "New Brunswick", Text = "New Brunswick" },
                new SelectListItem { Value = "Nova Scotia", Text = "Nova Scotia" },
                new SelectListItem { Value = "Prince Edward Island", Text = "Prince Edward Island" },
                new SelectListItem { Value = "Newfoundland and Labrador", Text = "Newfoundland and Labrador" },
                new SelectListItem { Value = "Yukon ", Text = "Yukon " },
                new SelectListItem { Value = "Northwest Territories", Text = "Northwest Territories" },
                new SelectListItem { Value = "Nunavut ", Text = "Nunavut " },
            };
        }
    }
}
