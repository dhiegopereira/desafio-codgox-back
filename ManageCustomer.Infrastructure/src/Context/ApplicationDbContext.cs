using ManageCustomer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManageCustomer.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Customer> Customer { get; set; }
}
