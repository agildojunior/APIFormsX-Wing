using APIFormsX_Wing.Models;

namespace APIFormsX_Wing.Repositorys.interfaces
{
    public interface IPollRepository
    {
        Task<List<Poll>> GetAll();
        Task<Poll> GetId(int id);
        Task<Poll> Create(Poll poll);
        Task<Poll> Edit(Poll poll, int id);
    }
}