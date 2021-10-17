using System.Threading.Tasks;
using Luna.Commons.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Luna.Commons.Authentication
{
    public class LunaSignInManager : SignInManager<LunaIdentityUser>
    {
        public LunaSignInManager(UserManager<LunaIdentityUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<LunaIdentityUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<LunaSignInManager> logger,
            IAuthenticationSchemeProvider schemes,
            IUserConfirmation<LunaIdentityUser> confirmation
        ) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }

        public override async Task<SignInResult> CheckPasswordSignInAsync(LunaIdentityUser user, string password, bool lockoutOnFailure)
        {
            if (!user.IsActive)
            {
                Logger.LogWarning("L'utilisateur {userEmail} est désactivé", user.Email);

                return SignInResult.NotAllowed;
            }
            
            return await base.CheckPasswordSignInAsync(user, password, lockoutOnFailure);
        }
    }
}