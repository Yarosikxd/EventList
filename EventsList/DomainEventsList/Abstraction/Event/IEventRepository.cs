using DomainEventsList.Models;

namespace DomainEventsList.Abstraction.Event
{
    public interface IEventRepository
    {
        Task<List<Evant>> GetAllEventsAsync();
        Task<Guid> CreateEventAsync(Evant evant);
        Task<Guid> UpdateEventAsync(Guid id, string title, string description, DateTime start, DateTime finished, decimal price, string comment, Guid userId);
        Task<Guid> DeleteEventAsync(Guid id);
        Task<Evant> GetEventByIdAsync(Guid id);
        Task<List<Evant>> GetEventForNextWeekAsync();
    }
}
