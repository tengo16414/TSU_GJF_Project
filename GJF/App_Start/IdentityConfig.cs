


using GJF.Domain.Entities;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace GJF
{
    public class IdentityConfig
    {
        public static ClaimsIdentity CreateClaimsIdentity(User user)
        {
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.UserName) }, DefaultAuthenticationTypes.ApplicationCookie);

            foreach (var userRole in user.UserRoles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, userRole.Role.Name));
            }

            return identity;
        }
    }
}
