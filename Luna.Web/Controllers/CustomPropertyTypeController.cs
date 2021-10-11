using Autofac;
using Luna.Commons.Models;

namespace Luna.Controllers
{
    public class CustomPropertyTypeController : EntityController<CustomPropertyType>
    {
        protected override string _entityName => "Type de propriété personnalisée";

        public CustomPropertyTypeController(ILifetimeScope scope) : base(scope)
        {
        }
    }
}