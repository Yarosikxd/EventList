using DataAccessEventsList.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessEventsList.Congigurations
{
    public class EventsConfiguration : IEntityTypeConfiguration<EventsEntity>
    {
        public void Configure(EntityTypeBuilder<EventsEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.
                HasMany(e => e.Users)
                .WithMany(u => u.Events);

        }
    }
}
