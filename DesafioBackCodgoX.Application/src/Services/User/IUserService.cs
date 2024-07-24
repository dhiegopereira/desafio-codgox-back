using DesafioBackCodgoX.Application.DTOs;

namespace DesafioBackCodgoX.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserListDto> GetByIdAsync(string id);
        Task<IEnumerable<UserListDto>> GetAllAsync();
        Task AddAsync(CreateUpdateUserDto createUpdateUserDto);
        Task UpdateAsync(string id, CreateUpdateUserDto createUpdateUserDto);
        Task DeleteAsync(string id);
    }
}
