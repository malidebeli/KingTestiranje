using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TicketOffice.Core.Models.Identity;
using TicketOffice.Core.Services;
using TicketOffice.Core.Services.Identity;
using TicketOffice.Data;
using TicketOffice.Services.Configuration;

namespace TicketOffice.Services
{
    public static class ServicesRegistration
    {
        public static IServiceCollection ConfigureServicesRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IOrderService, OrderService>();

            //identity authentication
            services.AddIdentity<AppUser, Role>()
                       .AddEntityFrameworkStores<TicketOfficeDbContext>()
                       .AddDefaultTokenProviders();
            services.AddTransient<IAuthService, AuthService>();
            services.Configure<JwtConfiguration>(configuration.GetSection("JwtConfiguration"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtConfiguration:Issuer"],
                        ValidAudience = configuration["JwtConfiguration:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfiguration:Key"]))
                    };
                });
            return services;
        }
    }
}
