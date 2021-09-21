using Autofac;
using Microsoft.AspNetCore.Mvc;

namespace Luna.Mvc
{
    public class BaseController : Controller
    {
        protected ILifetimeScope _scope { get; set; }
        
        public BaseController(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}