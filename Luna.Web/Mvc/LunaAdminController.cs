using Autofac;
using Luna.Commons.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Luna.Mvc
{
    [Area("Admin")]
    [Authorize(Roles = LunaApplicationRole.Admin)]
    public class LunaAdminController : LunaBaseController
    {
        public LunaAdminController(ILifetimeScope scope) : base(scope)
        {
        }
    }
}