using APIFormsX_Wing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIFormsX_Wing.Data.Map
{
    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.UserId).IsRequired();
            builder.Property(a => a.QuestionId).IsRequired();
            builder.Property(a => a.AnsweroptionId);
            builder.Property(a => a.AnswerText);
        }
    }
}