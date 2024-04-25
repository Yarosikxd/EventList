

namespace DataAccessEventsList.Entites
{
    public class UserEntity
    {

        public UserEntity()
        {
            
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string CityLive { get; set; }
        public DateTime CreatedAc { get; set; }
        public Guid EventId { get; set; }
        public List<EventsEntity> Events { get; set; }

    }
}
