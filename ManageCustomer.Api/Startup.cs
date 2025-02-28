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
       
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Manage Customer API",
                Version = "v1",
                Description = "API de Gerenciamento de Clientes",
                Contact = new OpenApiContact
                {
                    Name = "Suporte",
                    Email = "suporte@empresa.com"
                }
            });
        });

    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
        app.UseCors("AllowAllOrigins");

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Manage Customer API");
        });

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

}