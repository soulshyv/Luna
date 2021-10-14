using Autofac;
using Luna.Commons.Models;
using Microsoft.AspNetCore.Mvc;

namespace Luna.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomPropertyTypeController : EntityController<CustomPropertyType>
    {
        protected override string _entityName => "Type de propriété personnalisée";

        public CustomPropertyTypeController(ILifetimeScope scope) : base(scope)
        {
        }
    }
}