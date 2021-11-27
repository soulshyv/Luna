using Autofac;
using Luna.Commons.Models;

namespace Luna.Areas.Admin.Controllers
{
    public partial class CharacterTypeController : EntityController<CharacterType>
    {
        protected override string _entityName => "Type de personnage";

        public CharacterTypeController(ILifetimeScope scope) : base(scope)
        {
        }
    }
}