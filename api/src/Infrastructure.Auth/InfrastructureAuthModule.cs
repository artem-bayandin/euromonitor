using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Auth
{
    public class ApplicationUser : IdentityUser
    {
    }

    public static class InfrastructureAuthModule
    {
        public static IServiceCollection AddInfrastructureAuthModule(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                   .AddEntityFrameworkStores<EmContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, EmContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
