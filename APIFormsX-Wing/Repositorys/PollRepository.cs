using APIFormsX_Wing.Data;
using APIFormsX_Wing.Models;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIFormsX_Wing.Repositorys
{
    public class PollRepository : IPollRepository
    {
        private readonly SystemDBContext _dbContext;

        public PollRepository(SystemDBContext systemDBContext)
        {
            _dbContext = systemDBContext;
        }

        public async Task<Poll> GetId(int id)
        {
            return await _dbContext.Polls.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Poll>> GetAll()
        {
            return await _dbContext.Polls.ToListAsync();
        }

        public async Task<Poll> Create(Poll poll)
        {
            await _dbContext.Polls.AddAsync(poll);
            await _dbContext.SaveChangesAsync();

            return poll;
        }

        public async Task<Poll> Edit(Poll poll, int id)
        {
            Poll existingPoll = await GetId(id);

            if (existingPoll == null)
            {
                throw new Exception("Poll não encontrada.");
            }

            existingPoll.UserId = poll.UserId;
            existingPoll.City = poll.City;
            existingPoll.Date = poll.Date;

            _dbContext.Polls.Update(existingPoll);
            await _dbContext.SaveChangesAsync();

            return existingPoll;
        }
    }
}