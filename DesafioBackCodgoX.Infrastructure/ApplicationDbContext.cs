using DesafioBackCodgoX.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioBackCodgoX.Infrastructure;

 public class ApplicationDbContext : DbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        public DbSet<User> User {  get; set; }
    }

