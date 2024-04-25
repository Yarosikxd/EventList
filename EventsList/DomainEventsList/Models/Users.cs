

namespace DomainEventsList.Models
{
    public class Users
    {
        private Users(Guid id, string fullName, string email, string description, string cityLive, DateTime createdAc,Guid eventId)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Description = description;
            CityLive = cityLive;
            CreatedAc = createdAc;
            EventId = eventId;
            Events = new List<Evant> { };
        }

        public Guid Id { get; }
        public string FullName { get; }
        public string Email { get; }
        public string Description { get; }
        public string CityLive { get; }
        public DateTime CreatedAc { get; }
        public Guid EventId { get; set; }
        public List<Evant> Events { get; set; }

        public static (Users User, string Error) Create(Guid id, string fullName, string email, string description, string cityLive, DateTime createdAc, Guid eventId)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(fullName))
            {
                error = "Full Name can't be empty";
            }

            var user = new Users(id, fullName, email, description, cityLive, createdAc, eventId);

            return (user, error);
        }
    }
}
