using Autofac;
using Luna.Commons.Models;
using Microsoft.AspNetCore.Mvc;

namespace Luna.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RaceController : EntityController<Race>
    {
        protected override string _entityName => "Race";

        public RaceController(ILifetimeScope scope) : base(scope)
        {
        }
    }
}