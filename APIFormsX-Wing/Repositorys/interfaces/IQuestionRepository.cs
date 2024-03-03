using APIFormsX_Wing.Models;

namespace APIFormsX_Wing.Repositorys.interfaces
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAll();
        Task<Question> GetId(int id);
        Task<Question> Create(Question question);
        Task<Question> Edit(Question question, int id);
        Task<bool> Delete(int id);
    }
}