using ManageCustomer.Application.DTOs;

namespace ManageCustomer.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerListDto> GetByIdAsync(long id);
        Task<IEnumerable<CustomerListDto>> GetAllAsync();
        Task AddAsync(CreateUpdateCustomerDto createUpdateUserDto);
        Task UpdateAsync(long id, CreateUpdateCustomerDto createUpdateUserDto);
        Task DeleteAsync(long id);
    }
}
