using ManageCustomer.Domain.Entities;

namespace ManageCustomer.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(long id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        Task UpdateAsync(long id, Customer customer);
        Task DeleteAsync(long id);
    }
}
