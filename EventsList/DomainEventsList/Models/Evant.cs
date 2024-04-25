namespace DomainEventsList.Models
{
    public class Evant
    {
        private Evant(Guid id, string title, string description, DateTime start, DateTime finished, decimal price, string comment, Guid userId)
        {
            Id = id;
            Title = title;
            Description = description;
            Start = start;
            Finished = finished;
            Price = price;
            Comment = comment;
            UserId = userId;
            Users = new List<Users>(); 
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime Start { get; }
        public DateTime Finished { get; }
        public decimal Price { get; }
        public string Comment { get; }
        public Guid UserId { get; } 
        public List<Users> Users { get; set; } 

        public static (Evant Event, string Error) Create(Guid id, string title, string description, DateTime start, DateTime finished, decimal price, string comment, Guid userId)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title))
            {
                error = "Title can't be empty";
            }

            var events = new Evant(id, title, description, start, finished, price, comment, userId);

            return (events, error);
        }
    }
}
