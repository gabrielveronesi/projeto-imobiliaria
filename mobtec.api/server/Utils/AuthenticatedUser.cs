using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace server.Utils
{
    public class AuthenticatedUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthenticatedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Id => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
        // public string Email => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;
        // public string Name => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;
        //public string Email => _accessor.HttpContext.User.Identity.;

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public class UserAuthenticated
        {
            public string Email { get; set; }

        }
        // public class UserEstablishments
        // {
        //     public List<Establishment> Establishments { get; set; }

        // }
    }
}