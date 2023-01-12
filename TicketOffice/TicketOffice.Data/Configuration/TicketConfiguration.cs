using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core.Models;

namespace TicketOffice.Data.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
               .HasKey(t => t.TicketId);

            builder
               .HasOne(o => o.Order)
               .WithMany(t => t.Tickets)
               .HasForeignKey(o => o.OrderId);

            builder
             .Property(t => t.FromLocation)
             .IsRequired();

            builder
             .Property(t => t.FromLocation)
             .IsRequired();


            builder
             .Property(t => t.ToLocation)
             .IsRequired();


            builder
             .Property(t => t.Price)
             .IsRequired();
        }
    }
}

