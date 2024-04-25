using DomainEventsList.Models;

namespace DomainEventsList.Abstraction.User
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsersAsync();
        Task<Guid> CreateUserAsync(Users user);
        Task<Guid> UpdateUserAsync(Guid id, string fullName, string email, string description, string cityLive, DateTime createdAc, Guid eventId);
        Task<Guid> DeleteUserAsync(Guid id);
        Task<List<Users>> GetUserById(Guid id);
    }
}
