using APIFormsX_Wing.Models;

namespace APIFormsX_Wing.Repositorys.interfaces
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAll();
        Task<Answer> GetId(int id);
        Task<Answer> Create(Answer answer);
        Task<Answer> Edit(Answer answer, int id);
        Task<bool> Delete(int id);
    }
}