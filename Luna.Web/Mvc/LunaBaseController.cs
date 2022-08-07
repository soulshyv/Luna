using Autofac;
using Luna.Commons.Authentication;
using Luna.Commons.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Luna.Mvc
{
    [Authorize(AuthenticationSchemes = "Identity.Application")]
    public class LunaBaseController : Controller
    {
        protected ILifetimeScope Scope { get; set; }
        
        protected LunaIdentityUser CurrentUser { get; set; }
        
        private LunaUserManager _lunaUserManager;
        private LunaUserManager LuneUserManager => _lunaUserManager ??= Scope.Resolve<LunaUserManager>();
        
        public LunaBaseController(ILifetimeScope scope)
        {
            Scope = scope;
        }
    }
}