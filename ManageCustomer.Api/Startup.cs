using System.Reflection;
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
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddControllers();

        services.AddCors(options =>
       {
           options.AddPolicy("AllowAll",
               builder => builder
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());
       });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ManageCustomer.Api",
                Version = "v1",
                Description = "API para gerenciamento de clientes",
                Contact = new OpenApiContact
                {
                    Name = "Diego",
                    Email = "seuemail@exemplo.com"
                }
            });

            c.EnableAnnotations();
            c.UseAllOfForInheritance();
        });


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ManageCustomer API v1");
            c.RoutePrefix = string.Empty;
        });

        app.UseRouting();
        app.UseCors("AllowAll");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

}
