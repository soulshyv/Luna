using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Communication.Interfaces;
using Luna.Commons.Communication.Models;
using Luna.Commons.Models.Identity;
using Luna.Commons.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Luna.Commons.Authentication
{
    public class LunaUserManager : UserManager<LunaIdentityUser>
    {
        private ILifetimeScope _scope { get; set; }
        
        private IMailService _mailService;
        private IMailService MailService => _mailService ??= _scope.Resolve<IMailService>();
        
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
        
        public LunaUserManager(
            IUserStore<LunaIdentityUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<LunaIdentityUser> passwordHasher,
            IEnumerable<IUserValidator<LunaIdentityUser>> userValidators,
            IEnumerable<IPasswordValidator<LunaIdentityUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<LunaUserManager> logger,
            ILifetimeScope scope
        ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
            _scope = scope;
        }

        public async Task<bool> SendEmailConfirmation(LunaIdentityUser user)
        {
            var token = await GenerateEmailConfirmationTokenAsync(user);
            
            var urlBuilder = _scope.Resolve<LunaUrlBuilder>();

            var link = urlBuilder.Make("ConfirmEmail", "Account", new Dictionary<string, string>
            {
                { "token", token },
                { "id", user.Id.ToString() }
            });

            try
            {
                await MailService.Send(new Mail
                {
                    To = new Person(user),
                    Subject = "Luna - Confirmation de votre compte",
                    Body = @$"
                                <p>Bonjour {user.FirstName}</p>
                                <p>Pour confirmer votre inscription, veuillez suivre ce <a href=""{link}"" target=""_blank"">lien</a>.</p>
                            "
                });
                
                return true;
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Erreur lors de l'envoi du mail de confirmation de mail");
                
                return false;
            }
        }
    }
    
}