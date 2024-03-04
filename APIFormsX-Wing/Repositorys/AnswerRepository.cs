using APIFormsX_Wing.Data;
using APIFormsX_Wing.Models;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIFormsX_Wing.Repositorys
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly SystemDBContext _dbContext;

        public AnswerRepository(SystemDBContext systemDBContext)
        {
            _dbContext = systemDBContext;
        }

        public async Task<Answer> GetId(int id)
        {
            return await _dbContext.Answers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Answer>> GetAll()
        {
            return await _dbContext.Answers.ToListAsync();
        }

        public async Task<Answer> Create(Answer answer)
        {
            await _dbContext.Answers.AddAsync(answer);
            await _dbContext.SaveChangesAsync();

            return answer;
        }

        public async Task<Answer> Edit(Answer answer, int id)
        {
            Answer existingAnswer = await GetId(id);

            if (existingAnswer == null)
            {
                throw new Exception("Answer não encontrada.");
            }

            existingAnswer.UserId = answer.UserId;
            existingAnswer.QuestionId = answer.QuestionId;
            existingAnswer.AnsweroptionId = answer.AnsweroptionId;
            existingAnswer.AnswerText = answer.AnswerText;

            _dbContext.Answers.Update(existingAnswer);
            await _dbContext.SaveChangesAsync();

            return existingAnswer;
        }

        public async Task<bool> Delete(int id)
        {
            var existingAnswer = await _dbContext.Answers.FirstOrDefaultAsync(p => p.Id == id);

            if (existingAnswer == null)
            {
                throw new Exception("Answer não encontrada.");
            }

            _dbContext.Answers.Remove(existingAnswer);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}