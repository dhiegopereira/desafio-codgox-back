using ManageCustomer.Application.DTOs;
using ManageCustomer.Application.Interfaces;
using ManageCustomer.Domain.Entities;
using ManageCustomer.Domain.Interfaces;

namespace ManageCustomer.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerListDto> GetByIdAsync(long id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return new CustomerListDto
            {
                Id = customer?.Id ?? 0,
                Nome = customer?.Nome ?? string.Empty,
                Email = customer?.Email ?? string.Empty,
                Telefone = customer?.Telefone ?? string.Empty,
                DataNascimento = customer?.DataNascimento ?? default(DateTime)
            };
        }

        public async Task<IEnumerable<CustomerListDto>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return customers.Select(customer => new CustomerListDto
            {
                Id = customer?.Id ?? 0,
                Nome = customer?.Nome ?? string.Empty,
                Email = customer?.Email ?? string.Empty,
                Telefone = customer?.Telefone ?? string.Empty,
                DataNascimento = customer?.DataNascimento ?? default(DateTime)
            });
        }

        public async Task AddAsync(CreateUpdateCustomerDto createUpdateUserDto)
        {
            var customer = new Customer { Nome = createUpdateUserDto.Nome, Email = createUpdateUserDto.Email, Telefone = createUpdateUserDto.Telefone, DataNascimento = createUpdateUserDto.DataNascimento };
            await _customerRepository.AddAsync(customer);
        }

        public async Task UpdateAsync(long id, CreateUpdateCustomerDto createUpdateUserDto)
        {
            var customer = new Customer { Nome = createUpdateUserDto.Nome, Email = createUpdateUserDto.Email, Telefone = createUpdateUserDto.Telefone, DataNascimento = createUpdateUserDto.DataNascimento };
            await _customerRepository.UpdateAsync(id, customer);
        }

        public async Task DeleteAsync(long id)
        {
            await _customerRepository.DeleteAsync(id);
        }

    }
}
