using Domain.Auth;
using Domain.Interfaces;
using Infrastructure.Data.Contexts;
using Infrastructure.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.Infrastructure;

namespace WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // local implementation of interfaces
            services.AddScoped<IUserService, UserService>();

            // custom IoC
            services.RegisterDependencies(Configuration);

            services.AddHttpContextAccessor();

            // add identity  
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<EmContext>()
                .AddDefaultTokenProviders();

            // low password security
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
            });

            // add authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // add jwt
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            //// TODO: read docs
            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc(
            //        Configuration.GetValue<string>("Swagger:Version"),
            //        new OpenApiInfo
            //        {
            //            Title = Configuration.GetValue<string>("Swagger:Title"),
            //            Version = Configuration.GetValue<string>("Swagger:Version")
            //        });
            //});

            //// System.Text.Json (STJ) vs Newtonsoft
            //// Install-Package Swashbuckle.AspNetCore.Newtonsoft -Version 5.2.1
            //// link: https://github.com/domaindrivendev/Swashbuckle.AspNetCore
            //services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSwagger();
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint(
            //        Configuration.GetValue<string>("Swagger:JsonEndpoint")
            //        , $"{Configuration.GetValue<string>("Swagger:Title")} {Configuration.GetValue<string>("Swagger:Version")}"
            //    );
            //});
        }
    }
}
