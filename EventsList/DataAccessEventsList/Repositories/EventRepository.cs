using DataAccessEventsList.Entites;
using DomainEventsList.Abstraction.Event;
using DomainEventsList.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessEventsList.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventsListContext _context;

        public EventRepository(EventsListContext context)
        {
            _context = context;
        }

        public async Task<List<Evant>>GetAllEventsAsync()
        {
            var eventEntities = await _context.Events
                .AsNoTracking()
                .ToListAsync();

            var events = eventEntities
                .Select(e => Evant.Create(e.Id, e.Title,e.Description, e.Start,e.Finished,e.Price,e.Comment,e.UserId).Event)
                .ToList();

            return events;
        }

        public async Task<Guid>CreateEventAsync(Evant evant)
        {
            var eventEntity = new EventsEntity
            {
                Id = evant.Id,
                Title = evant.Title,
                Description = evant.Description,
                Start = evant.Start,
                Finished = evant.Finished,
                Price = evant.Price,
                Comment = evant.Comment,
                UserId = evant.UserId
            };

            await _context.Events.AddAsync(eventEntity);
            await _context.SaveChangesAsync();

            return eventEntity.Id;
        }

        public async Task<Guid>UpdateEventAsync(Guid id, string title, string description, DateTime start, DateTime finished, decimal price, string comment, Guid userId)
        {
            var evant = await _context.Events.FindAsync(id);
            if(evant != null)
            {
                evant.Title = title;
                evant.Description = description;
                evant.Start = start;
                evant.Finished = finished;
                evant.Price = price;
                evant.Comment = comment;
                evant.UserId = userId;
            }

            return id;
        }

        public async Task<Guid>DeleteEventAsync(Guid id)
        {
            var evant = await _context.Events.FindAsync(id);
            if(evant != null)
            {
                _context.Events.Remove(evant);
                await _context.SaveChangesAsync();
            }
            
            return id;
        }

        public async Task<Evant>GetEventByIdAsync(Guid id)
        {
          var eventEntity = await _context.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

          var evant = Evant.Create
              (
              eventEntity.Id,
              eventEntity.Title,
              eventEntity.Description,
              eventEntity.Start,
              eventEntity.Finished,
              eventEntity.Price,
              eventEntity.Comment,
              eventEntity.UserId
              );

            return evant.Event;
        }

        public async Task<List<Evant>>GetEventForNextWeekAsync()
        {
            DateTime startOfWeek = DateTime.Today.AddDays(1);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            var eventEntities = await _context.Events
                .AsNoTracking()
                .Where(e => e.Start >= startOfWeek && e.Start <= endOfWeek)
                .ToListAsync();

            var evants = eventEntities
                .Select( e => Evant.Create(
                     e.Id,
                     e.Title,
                     e.Description,
                     e.Start,
                     e.Finished,
                     e.Price,
                     e.Comment,
                     e.UserId
                     ).Event)
                     .ToList();

            return evants;
        }
    }
}
