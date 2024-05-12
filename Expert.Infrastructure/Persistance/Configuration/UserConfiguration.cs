using Expert.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expert.Infrastructure.Persistance.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.UserSkills).WithOne()
                                              .HasForeignKey(u => u.IdSkill)
                                              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
