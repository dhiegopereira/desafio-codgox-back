using DesafioBackCodgoX.Domain.Entities;
using DesafioBackCodgoX.Domain.Interfaces;

namespace DesafioBackCodgoX.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users = new List<User>();

        public async Task<User> GetByIdAsync(string id)
        {
            return await Task.FromResult(Users.FirstOrDefault(u => u.Id == id));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(Users.AsEnumerable());
        }

        public async Task AddAsync(User user)
        {
            Users.Add(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(string id, User user)
        {
            var existingUser = Users.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(string id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                Users.Remove(user);
            }
            await Task.CompletedTask;
        }
    }
}