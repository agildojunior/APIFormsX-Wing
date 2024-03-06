using APIFormsX_Wing.Models;

namespace APIFormsX_Wing.Repositorys.interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetId(int id);
        Task<User> Create(User user);
        Task<User> Edit(User user, int id);
        Task<bool> Delete(int id);
        Task<User> GetByUsername(string username);
        Task<User> GetByUsernameAndPassword(string username, string password);
    }
}
