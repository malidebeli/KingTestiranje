using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core.Models;

namespace TicketOffice.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
            .HasKey(m => m.OrderId);


            builder
             .Property(t => t.CustomerId)
             .IsRequired();

            builder
             .Property(t => t.Timestamp)
             .IsRequired();
        }
    }
}
