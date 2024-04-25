using DomainEventsList.Abstraction.User;
using DomainEventsList.Models;


namespace ApplicationEventsList.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<Guid> CreateUserAsync(Users user)
        {
            return await _userRepository.CreateUserAsync(user);
        }

        public async Task<Guid> UpdateUserAsync(Guid id, string fullName, string email, string description, string cityLive, DateTime createdAc, Guid eventId)
        {
            return await _userRepository.UpdateUserAsync(id, fullName, email, description, cityLive, createdAc, eventId);
        }

        public async Task<Guid> DeleteUserAsync(Guid id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<List<Users>> GetUserById (Guid id)
        {
           var users = new List<Users>();

            var user = await _userRepository.GetUserByIdAsync(id);

            if(user != null)
            {
                users.Add(user);
            }

            return users;
        }
    }
}
