using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core;

namespace TicketOffice.Data
{
        public static class DataRegistration
    {
        public static IServiceCollection ConfigureDataRegistration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TicketOfficeDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TicketOfficeDbContext"), x => x.MigrationsAssembly("TicketOffice.Data")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
