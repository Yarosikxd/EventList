namespace ViewApiEventsList.Contacts.Event
{
    public class EventRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finished { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
    };
    
}
