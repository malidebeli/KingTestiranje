using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TicketOffice.Api.Resources;
using TicketOffice.Core.Models;
using TicketOffice.Core.Services.Identity;
using TicketOffice.Services;

namespace TicketOffice.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authn : ControllerBase
    {
        private readonly IAuthService _authService;
        public Authn(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult<string>> LogIn(UserCredentialResource userCredentialResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user =_authService.GetUserByUsername(userCredentialResource.Username);
            if (user is null)
            {
                return NotFound("Korisnik ne postoji");
            }
            return  await _authService.Login(user);                    
        }  
  
    }
}
