using DomainEventsList.Abstraction.Event;
using DomainEventsList.Models;

namespace ApplicationEventsList.Services
{
    public class EventService: IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<List<Evant>>GetAllEventsAsync()
        {
            return await _eventRepository.GetAllEventsAsync();
        }

        public async Task<Guid>CreateEventAsync(Evant evant)
        {
            return await _eventRepository.CreateEventAsync(evant);
        }

        public async Task<Guid>UpdateEventAsync(Guid id, string title, string description, DateTime start, DateTime finished, decimal price, string comment, Guid userId)
        {
            return await _eventRepository.UpdateEventAsync(id, title, description, start, finished, price, comment, userId);
        }

        public async Task<Guid>DeleteEventAsync(Guid id)
        {
            return await _eventRepository.DeleteEventAsync(id);
        }

        public async Task<List<Evant>>GetEventById(Guid id)
        {
            var evants = new List<Evant>();

            var evant = await _eventRepository.GetEventByIdAsync(id);

            if(evant != null)
            {
                evants.Add(evant);
            }

            return evants;
        }

        public async Task<List<Evant>> GetEventForNextWeekAsync()
        {
            var eventsForNextWeek = await _eventRepository.GetEventForNextWeekAsync();
            return eventsForNextWeek;
        }
    }
}
