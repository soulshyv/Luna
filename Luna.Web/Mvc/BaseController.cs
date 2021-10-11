using Autofac;
using Luna.Commons.Models.Identity;
using Luna.Commons.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Luna.Mvc
{
    public class BaseController : Controller
    {
        protected ILifetimeScope _scope { get; set; }
        
        protected LunaIdentityUser CurrentUser { get; set; }
        
        private LunaUserManager _lunaUserManager;
        private LunaUserManager LuneUserManager => _lunaUserManager ??= _scope.Resolve<LunaUserManager>();
        
        public BaseController(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}