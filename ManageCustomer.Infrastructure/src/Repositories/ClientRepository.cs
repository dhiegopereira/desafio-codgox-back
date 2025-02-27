using ManageCustomer.Domain.Entities;
using ManageCustomer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManageCustomer.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext context;

        public CustomerRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<Customer> GetByIdAsync(long id)
        {
            var customer = await context.Customer.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await context.Customer.ToListAsync();
        }

        public async Task AddAsync(Customer user)
        {
            var customerExists = context.Customer.Any(u => u.Email == user.Email);
            if (customerExists)
            {
                throw new Exception("Customer already exists");
            }
            await context.Customer.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(long id, Customer customer)
        {
            var existingCustomer = await context.Customer.FindAsync(id);
            if (existingCustomer is null)
            {
                throw new Exception("Customer not found");
            }

            existingCustomer.Nome = customer.Nome;
            existingCustomer.Email = customer.Email;
            existingCustomer.Telefone = customer.Telefone;
            existingCustomer.DataNascimento = customer.DataNascimento;

            await context.SaveChangesAsync();
        }


        public async Task DeleteAsync(long id)
        {
            var customer = context.Customer.FirstOrDefault(u => u.Id == id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            context.Customer.Remove(customer);
            await context.SaveChangesAsync();
        }
    }
}
