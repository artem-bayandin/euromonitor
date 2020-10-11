using Application;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Infrastructure.IoC
{
    public static class InfrastructureIocModule
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // register 'modules' (contain internal registration for automapper and mediatr)
            services.AddDomainModule();
            services.AddApplicationModule();

            // add database
            services
                .AddDbContext<EmContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("EntitiesDatabase"),
                    // enable auto migrations
                    optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(EmContext).Assembly.GetName().Name)
                )
            );

            // register context
            services.AddScoped<IEmContext>(provider => provider.GetService<EmContext>());

            // add automapper
            services.AddAutoMapper(typeof(DomainModule).Assembly, typeof(ApplicationModule).Assembly);

            // validation
            services.AddControllers()
                .AddFluentValidation(options => {
                    options.RegisterValidatorsFromAssembly(typeof(ApplicationModule).Assembly);
                    options.RegisterValidatorsFromAssembly(typeof(DomainModule).Assembly);
                });

            return services;
        }
    }
}
