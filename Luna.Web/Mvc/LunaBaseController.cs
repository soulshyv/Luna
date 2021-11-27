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
        protected ILifetimeScope _scope { get; set; }
        
        protected LunaIdentityUser CurrentUser { get; set; }
        
        private LunaUserManager _lunaUserManager;
        private LunaUserManager LuneUserManager => _lunaUserManager ??= _scope.Resolve<LunaUserManager>();
        
        public LunaBaseController(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}