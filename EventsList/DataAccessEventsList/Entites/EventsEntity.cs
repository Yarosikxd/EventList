

namespace DataAccessEventsList.Entites
{
    public class EventsEntity
    {

        public EventsEntity()
        {
            
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finished { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
