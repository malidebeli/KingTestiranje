using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TicketOffice.Core.Models;
using TicketOffice.Core.Models.Identity;
using TicketOffice.Data.Configuration;

namespace TicketOffice.Data
{
    public class TicketOfficeDbContext: IdentityDbContext<AppUser, Role, Guid>
    {
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Order> Order { get; set; }

        public TicketOfficeDbContext(DbContextOptions<TicketOfficeDbContext> options)
           : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .ApplyConfiguration(new TicketConfiguration());
            builder
                .ApplyConfiguration(new OrderConfiguration());
        }
    }
}