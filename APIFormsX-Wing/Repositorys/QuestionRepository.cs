using APIFormsX_Wing.Data;
using APIFormsX_Wing.Models;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIFormsX_Wing.Repositorys
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly SystemDBContext _dbContext;

        public QuestionRepository(SystemDBContext systemDBContext)
        {
            _dbContext = systemDBContext;
        }

        public async Task<Question> GetId(int id)
        {
            return await _dbContext.Questions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Question>> GetAll()
        {
            return await _dbContext.Questions.ToListAsync();
        }

        public async Task<Question> Create(Question question)
        {
            await _dbContext.Questions.AddAsync(question);
            await _dbContext.SaveChangesAsync();

            return question;
        }

        public async Task<Question> Edit(Question question, int id)
        {
            Question existingQuestion = await GetId(id);

            if (existingQuestion == null)
            {
                throw new Exception("Questão não encontrada.");
            }

            existingQuestion.QuestionText = question.QuestionText;
            existingQuestion.Type = question.Type;

            _dbContext.Questions.Update(existingQuestion);
            await _dbContext.SaveChangesAsync();

            return existingQuestion;
        }

        public async Task<bool> Delete(int id)
        {
            var existingQuestion = await _dbContext.Questions.FirstOrDefaultAsync(q => q.Id == id);

            if (existingQuestion == null)
            {
                throw new Exception("Questão não encontrada.");
            }

            _dbContext.Questions.Remove(existingQuestion);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}