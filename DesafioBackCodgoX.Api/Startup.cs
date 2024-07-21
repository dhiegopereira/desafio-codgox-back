using DesafioBackCodgoX.Application.Interfaces;
using DesafioBackCodgoX.Application.Services;
using DesafioBackCodgoX.Domain.Interfaces;
using DesafioBackCodgoX.Infrastructure;
using DesafioBackCodgoX.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContextFactory<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("TestDatabase"));

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScoped<IUserService, UserService>();        
        services.AddScoped<IUserRepository, UserRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
