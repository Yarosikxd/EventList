

namespace ViewApiEventsList.Contacts.Event
{
    public class EventResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finished { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
        public Guid UserId { get; set; }
    }

}
