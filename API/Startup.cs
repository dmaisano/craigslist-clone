using API.Data;
using API.Utilities;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly); // ? Import the automapper util method
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            });

            services.AddControllers();

            services.AddCors();

            // ? Reference: https://www.codemag.com/Article/2105051/Implementing-JWT-Authentication-in-ASP.NET-Core-5
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])), // ? The JWT secret
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true, // ? Reject expired tokens
                    };
                });

            // ? Reference: https://docs.microsoft.com/en-us/aspnet/core/security/authorization/policies?view=aspnetcore-6.0
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                .WithOrigins("http://localhost:1234"));

            app.UseAuthentication(); // ? This must be called before UseAuthorization()
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
