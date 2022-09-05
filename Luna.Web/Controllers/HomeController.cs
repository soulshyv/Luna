using System.Diagnostics;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Luna.Models;
using Luna.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Hosting;

namespace Luna.Controllers
{
    public class HomeController : LunaBaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ILifetimeScope scope) : base(scope)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        
        // #if DEBUG
        // [AllowAnonymous]
        // #endif
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            
            var vm = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                CanDisplayFullError = Scope.Resolve<IHostEnvironment>()?.IsDevelopment() ?? false,
                Error = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error
            };
            return View(vm);
        }
    }
}