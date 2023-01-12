using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core.Models;
using TicketOffice.Core.Models.Identity;

namespace TicketOffice.Data.Configuration.Identity
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .Property(t => t.FirstName)
                .IsRequired();
             builder
             .Property(t => t.LastName)
             .IsRequired();
        }    
    }
}
