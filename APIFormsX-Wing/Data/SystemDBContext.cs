using Microsoft.EntityFrameworkCore;
using APIFormsX_Wing.Models;
using APIFormsX_Wing.Data.Map;

namespace APIFormsX_Wing.Data
{
    public class SystemDBContext : DbContext
    {
        public SystemDBContext(DbContextOptions<SystemDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answeroption> Answeroptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PollMap());
            modelBuilder.ApplyConfiguration(new QuestionMap());
            modelBuilder.ApplyConfiguration(new AnsweroptionMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}