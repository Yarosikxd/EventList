using DataAccessEventsList;
using DataAccessEventsList.Repositories;
using DomainEventsList.Models;
using Microsoft.EntityFrameworkCore;


namespace TestMethodth
{
    public class TestRepository
    {
        private readonly UserRepository _userRepository;

        public TestRepository(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RunAsync()
        {
            // Створення об'єкту User за допомогою фабричного методу
            var userCreationResult = Users.Create(Guid.NewGuid(), "John Doe", "john@example.com", "Description", "City", DateTime.Now, Guid.NewGuid());

            // Перевірка на наявність помилок під час створення
            if (!string.IsNullOrEmpty(userCreationResult.Error))
            {
                Console.WriteLine($"Error occurred: {userCreationResult.Error}");
                return;
            }

            var newUser = userCreationResult.User;

            // Виклик методу CreateUserAsync для створення користувача
            var userId = await _userRepository.CreateUserAsync(newUser);

            // Виведення ідентифікатора створеного користувача
            Console.WriteLine($"New user created with ID: {userId}");
        }

        static async Task Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventsListContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-68LLRBR;Initial Catalog=EventsList;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Encrypt=False");

            var dbContext = new EventsListContext(optionsBuilder.Options);
            var userRepository = new UserRepository(dbContext);

            var testRepository = new TestRepository(userRepository);
            await testRepository.RunAsync();
        }
    }

}
