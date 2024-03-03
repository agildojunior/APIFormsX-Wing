using APIFormsX_Wing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIFormsX_Wing.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Administrator).IsRequired();
            builder.Property(x => x.Password).IsRequired().HasMaxLength(50);
        }
    }
}
