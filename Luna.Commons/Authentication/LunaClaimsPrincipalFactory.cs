using Luna.Commons.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Luna.Commons.Authentication
{
    public class LunaClaimsPrincipalFactory : UserClaimsPrincipalFactory<LunaIdentityUser, LunaIdentityRole>
    {
        public LunaClaimsPrincipalFactory(
            LunaUserManager userManager,
            LunaRoleManager roleManager,
            IOptions<IdentityOptions> options
        ) : base(userManager, roleManager, options)
        {
        }
    }
}