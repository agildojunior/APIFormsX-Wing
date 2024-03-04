using APIFormsX_Wing.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIFormsX_Wing.Data.Map
{
    public class AnsweroptionMap : IEntityTypeConfiguration<Answeroption>
    {
        public void Configure(EntityTypeBuilder<Answeroption> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(x => x.QuestionId).IsRequired();
            builder.Property(a => a.OptionText);
        }
    }
}
