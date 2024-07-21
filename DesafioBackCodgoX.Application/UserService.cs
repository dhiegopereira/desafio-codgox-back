using DesafioBackCodgoX.Application.DTOs;
using DesafioBackCodgoX.Application.Interfaces;
using DesafioBackCodgoX.Domain.Entities;
using DesafioBackCodgoX.Domain.Interfaces;

namespace DesafioBackCodgoX.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;
            return new UserDto { Id = user.Id, Name = user.Name, Email = user.Email, Password = "" };
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserDto { Id = user.Id, Name = user.Name, Email = user.Email, Password = "" });
        }

        public async Task AddAsync(CreateUpdateUserDto createUpdateUserDto)
        {
            string id = Guid.NewGuid().ToString();
            var user = new User { Id = id, Name = createUpdateUserDto.Name, Email = createUpdateUserDto.Email, Password = createUpdateUserDto.Password };
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateAsync(string id, CreateUpdateUserDto createUpdateUserDto)
        {
            var user = new User { Name = createUpdateUserDto.Name, Email = createUpdateUserDto.Email, Password = createUpdateUserDto.Password };
            await _userRepository.UpdateAsync(id, user);
        }

        public async Task DeleteAsync(string id)
        {
            await _userRepository.DeleteAsync(id);
        }

    }
}