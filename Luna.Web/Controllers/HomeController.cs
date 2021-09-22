using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Models.Dtos;
using Luna.Commons.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Luna.Models;
using Luna.Mvc;

namespace Luna.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        
        private CharacterRepository _characterRepository { get; set; }

        private CharacterRepository CharacterRepository =>
            _characterRepository ??= _scope.Resolve<CharacterRepository>();

        public HomeController(ILogger<HomeController> logger, ILifetimeScope scope) : base(scope)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var characters = await CharacterRepository.GetAll();
            
            return View(characters.Select(_ => new CharacterDto(_)));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}