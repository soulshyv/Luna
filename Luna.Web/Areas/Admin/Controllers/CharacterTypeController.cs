using Autofac;
using Luna.Commons.Models;
using Microsoft.AspNetCore.Mvc;

namespace Luna.Areas.Admin.Controllers
{
    [Area("Admin")]
    public partial class CharacterTypeController : EntityController<CharacterType>
    {
        protected override string _entityName => "Type de personnage";

        public CharacterTypeController(ILifetimeScope scope) : base(scope)
        {
        }
    }
}