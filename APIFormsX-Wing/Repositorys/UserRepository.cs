using APIFormsX_Wing.Data;
using APIFormsX_Wing.Models;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIFormsX_Wing.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly SystemDBContext _dbContext;

        public UserRepository(SystemDBContext systemDBContext)
        {
            _dbContext = systemDBContext;
        }

        public async Task<User> GetId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> Create(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            User userId = await GetId(id);

            if (userId == null)
            {
                throw new Exception("Usuário nao encontrado.");
            }

            _dbContext.Users.Remove(userId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> Edit(User user, int id)
        {
            User userId = await GetId(id);

            if (userId == null)
            {
                throw new Exception("Usuário nao encontrado.");
            }
            userId.Username = user.Username;
            userId.Active = user.Active;
            userId.Password = user.Password;
            userId.Administrator = user.Administrator;

            _dbContext.Users.Update(userId);
            await _dbContext.SaveChangesAsync();

            return userId;
        }

    }
}
