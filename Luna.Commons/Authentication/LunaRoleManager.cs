using System.Collections.Generic;
using Luna.Commons.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Luna.Commons.Authentication
{
    public class LunaRoleManager : RoleManager<LunaIdentityRole>
    {
        public LunaRoleManager(
            IRoleStore<LunaIdentityRole> store,
            IEnumerable<IRoleValidator<LunaIdentityRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<LunaRoleManager> logger
        ) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}