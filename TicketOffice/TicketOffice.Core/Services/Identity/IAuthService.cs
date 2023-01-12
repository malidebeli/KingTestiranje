using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOffice.Core.Models.Identity;

namespace TicketOffice.Core.Services.Identity
{
    public interface IAuthService
    {
        Task<string> Login(AppUser user);
        AppUser GetUserByUsername(string username);
        AppUser GetUserById(Guid userId);
    }
}
