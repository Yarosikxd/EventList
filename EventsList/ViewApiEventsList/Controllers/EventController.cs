using DomainEventsList.Abstraction.Event;
using DomainEventsList.Models;
using Microsoft.AspNetCore.Mvc;


namespace ViewApiEventsList.Controllers
{
    public class EventController : Controller
    { 
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllEventsAsync();

            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Evant evant)
        {
            var success = await _eventService.CreateEventAsync(evant);
            
            return RedirectToAction("Index");
        }
    }
       


    
}
