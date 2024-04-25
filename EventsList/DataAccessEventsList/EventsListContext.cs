using DataAccessEventsList.Congigurations;
using DataAccessEventsList.Entites;
using Microsoft.EntityFrameworkCore;

namespace DataAccessEventsList
{
    public class EventsListContext: DbContext
    {
        public EventsListContext(DbContextOptions<EventsListContext> optins)
            : base(optins) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EventsConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<EventsEntity> Events { get; set; }
    }
}
