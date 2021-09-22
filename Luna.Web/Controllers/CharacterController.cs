using System.Threading.Tasks;
using Autofac;
using Luna.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Luna.Controllers
{
    public class CharacterController : BaseController
    {
        public CharacterController(ILifetimeScope scope) : base(scope)
        {
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }
    }
}