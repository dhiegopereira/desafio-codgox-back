using ManageCustomer.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using ManageCustomer.Application.Services;
using ManageCustomer.Infrastructure;
using ManageCustomer.Infrastructure.Repositories;
using ManageCustomer.Domain.Interfaces;
using Microsoft.OpenApi.Models;

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

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();


        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        
        app.UseCors("AllowAllOrigins");

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Guia Local API v1");
        });

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

}