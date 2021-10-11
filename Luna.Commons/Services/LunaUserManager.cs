using System;
using System.Collections.Generic;
using Luna.Commons.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Luna.Commons.Services
{
    public class LunaUserManager : UserManager<LunaIdentityUser>
    {
        public LunaUserManager(
            IUserStore<LunaIdentityUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<LunaIdentityUser> passwordHasher,
            IEnumerable<IUserValidator<LunaIdentityUser>> userValidators,
            IEnumerable<IPasswordValidator<LunaIdentityUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<LunaUserManager> logger
        ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}