using DataAccessEventsList.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessEventsList.Congigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {

        public void Configure(EntityTypeBuilder<UserEntity> builder) 
        {
            builder.HasKey(u => u.Id);

            builder.
                HasMany(u => u.Events)
                .WithMany(e => e.Users);
                
               
        }
        
    }
    
    
}
