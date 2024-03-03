using APIFormsX_Wing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIFormsX_Wing.Data.Map
{
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PollId).IsRequired();
            builder.Property(x => x.QuestionText).IsRequired();
            builder.Property(x => x.Type).IsRequired().HasMaxLength(10);
        }
    }
}
