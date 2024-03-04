using APIFormsX_Wing.Data;
using APIFormsX_Wing.Models;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIFormsX_Wing.Repositorys
{
    public class AnsweroptionRepository : IAnsweroptionRepository
    {
        private readonly SystemDBContext _dbContext;

        public AnsweroptionRepository(SystemDBContext systemDBContext)
        {
            _dbContext = systemDBContext;
        }

        public async Task<Answeroption> GetId(int id)
        {
            return await _dbContext.Answeroptions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Answeroption>> GetAll()
        {
            return await _dbContext.Answeroptions.ToListAsync();
        }

        public async Task<Answeroption> Create(Answeroption answeroption)
        {
            await _dbContext.Answeroptions.AddAsync(answeroption);
            await _dbContext.SaveChangesAsync();

            return answeroption;
        }

        public async Task<Answeroption> Edit(Answeroption answeroption, int id)
        {
            var existingAnsweroption = await GetId(id);

            if (existingAnsweroption == null)
            {
                throw new Exception("Answeroption não encontrado.");
            }

            existingAnsweroption.QuestionId = answeroption.QuestionId;
            existingAnsweroption.OptionText = answeroption.OptionText;

            _dbContext.Answeroptions.Update(existingAnsweroption);
            await _dbContext.SaveChangesAsync();

            return existingAnsweroption;
        }

        public async Task<bool> Delete(int id)
        {
            var existingAnsweroption = await _dbContext.Answeroptions.FirstOrDefaultAsync(a => a.Id == id);

            if (existingAnsweroption == null)
            {
                throw new Exception("Answeroption não encontrado.");
            }

            _dbContext.Answeroptions.Remove(existingAnsweroption);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}