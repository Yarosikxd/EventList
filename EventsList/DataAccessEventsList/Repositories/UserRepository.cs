using DataAccessEventsList.Entites;
using DomainEventsList.Abstraction.User;
using DomainEventsList.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessEventsList.Repositories
{
    public class UserRepository: IUserRepository
    {

        private readonly EventsListContext _context;

        public UserRepository(EventsListContext context)
        {
            _context = context;
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            var userEntities = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var users = userEntities
                .Select(u => Users.Create(u.Id, u.FullName, u.Email, u.Description, u.CityLive,  u.CreatedAc,u.EventId).User)
                .ToList();

            return users;
        }

        public async Task<Guid> CreateUserAsync(Users user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Description = user.Description,
                CityLive = user.CityLive,
                CreatedAc = user.CreatedAc,
                EventId = user.EventId,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<Guid> UpdateUserAsync(Guid id, string fullName, string email, string description, string cityLive, DateTime createdAc, Guid eventId)
        {
            var user = await _context.Users.FindAsync(id);
            if(user != null) 
            {
                user.FullName = fullName;
                user.Email = email;
                user.Description = description;
                user.CityLive = cityLive;
                user.CreatedAc = createdAc;
                user.EventId = eventId;
                await _context.SaveChangesAsync();
            }
            return id;
        }

        public async Task<Guid> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user != null )
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }

            return id;
        }

        public async Task<Users> GetUserByIdAsync(Guid id)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            var user = Users.Create(
                userEntity.Id,
                userEntity.FullName,
                userEntity.Email,
                userEntity.Description,
                userEntity.CityLive,
                userEntity.CreatedAc,
                userEntity.EventId
                );

            return user.User;
        }
    }
}
