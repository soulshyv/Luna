using Autofac;
using Luna.Commons.Models;

namespace Luna.Controllers
{
    public class CharacterTypeController : EntityController<CharacterType>
    {
        protected override string _entityName => "Type de personnage";

        public CharacterTypeController(ILifetimeScope scope) : base(scope)
        {
        }
    }
}