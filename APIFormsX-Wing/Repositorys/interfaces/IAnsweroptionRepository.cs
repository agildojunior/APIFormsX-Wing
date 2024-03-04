using APIFormsX_Wing.Models;

namespace APIFormsX_Wing.Repositorys.interfaces
{
    public interface IAnsweroptionRepository
    {
        Task<List<Answeroption>> GetAll();
        Task<Answeroption> GetId(int id);
        Task<Answeroption> Create(Answeroption poll);
        Task<Answeroption> Edit(Answeroption poll, int id);
        Task<bool> Delete(int id);
    }
}