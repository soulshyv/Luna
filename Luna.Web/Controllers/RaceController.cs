using Autofac;
using Luna.Commons.Models;

namespace Luna.Controllers
{
    public class RaceController : EntityController<Race>
    {
        protected override string _entityName => "Race";

        public RaceController(ILifetimeScope scope) : base(scope)
        {
        }
    }
}