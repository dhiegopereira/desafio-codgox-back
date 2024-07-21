using DesafioBackCodgoX.Application.DTOs;

namespace DesafioBackCodgoX.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(string id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task AddAsync(CreateUpdateUserDto createUpdateUserDto);
        Task UpdateAsync(string id, CreateUpdateUserDto createUpdateUserDto);
        Task DeleteAsync(string id);
    }
}
