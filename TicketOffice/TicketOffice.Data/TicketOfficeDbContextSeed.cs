using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core.Models;
using TicketOffice.Core.Models.Identity;

namespace TicketOffice.Data
{
    public class TicketOfficeDbContextSeed
    {    
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new TicketOfficeDbContext(serviceProvider.GetRequiredService<DbContextOptions<TicketOfficeDbContext>>()))
            using (var transaction = context.Database.BeginTransaction())
            {
                // Look for any movies.
                if (context.Order.Any() || context.Ticket.Any() || context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                UserManager<AppUser> userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
                var result = userManager.CreateAsync(
                     new AppUser
                     {
                         Id = Guid.Parse("fdf7ff8b-f899-4c42-b623-15e1aad9664e"),
                         Email = "josip.stavalj@gmail.com",
                         NormalizedEmail = "JOSIP.STAVALJ@GMAIL.COM",
                         FirstName = "Josip",
                         LastName = "Štavalj",
                         UserName = "jstavalj",
                         NormalizedUserName = "JSTAVALJ",
                         EmailConfirmed = true,
                         SecurityStamp = Guid.NewGuid().ToString("D"),
                         CardNumber = "1234",
                         Street = "Kolodvorskla",
                         City = "Zagreb",
                         State = "Hrvatksa",
                         Country = "Hrvatska"                        
                     }, "NeprobojnaSifra1!").Result;
                              
                context.Order.AddRange(
                    new Order
                    {
                        OrderId = 1,
                        CustomerId = "fdf7ff8b-f899-4c42-b623-15e1aad9664e",
                        Timestamp = DateTime.Now
                    },
                    new Order
                    {
                        OrderId = 2,
                        CustomerId = "fdf7ff8b-f899-4c42-b623-15e1aad9664e",
                        Timestamp = DateTime.Now
                    });
          
                context.Ticket.AddRange(
                    new Ticket
                    {
                        TicketId = Guid.NewGuid().ToString(),
                        OrderId = 1,
                        FromLocation ="Zagreb",
                        ToLocation ="Lipovljani",
                        Price =10.50M ,
                        Timestamp =DateTime.Now
                    },
                   new Ticket
                   {
                       TicketId = Guid.NewGuid().ToString(),
                       OrderId = 1,
                       FromLocation = "Kutina",
                       ToLocation = "Novska",
                       Price = 1.50M,
                       Timestamp = DateTime.Now
                   },
                    new Ticket
                    {
                        TicketId = Guid.NewGuid().ToString(),
                        OrderId = 2,
                        FromLocation = "Rijeka",
                        ToLocation = "Split",
                        Price = 100M,
                        Timestamp = DateTime.Now
                    },
                    new Ticket
                    {
                        TicketId = Guid.NewGuid().ToString(),
                        OrderId = 2,
                        FromLocation = "Varaždin",
                        ToLocation = "Osijek",
                        Price = 50.25M,
                        Timestamp = DateTime.Now
                    }
                );
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT TicketingSystem.dbo.[Order] ON;");
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT TicketingSystem.dbo.[Order] OFF;");
                transaction.Commit();
            }
        }
    }
}
