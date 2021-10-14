using System.Collections.Generic;
using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;

namespace Luna.Commons.Services
{
    public class LunaUrlBuilder
    {
        private IUrlHelper _urlHelper { get; set; }
        private HttpContext _httpContext { get; }
        private IConfiguration _configuration { get; }
        private ILifetimeScope _scope { get; set; }

        public LunaUrlBuilder(ILifetimeScope scope)
        {
            _scope = scope;
            _configuration = _scope.Resolve<IConfiguration>();
            
            if (
                _scope.TryResolve(out IHttpContextAccessor hca) && hca.HttpContext != null &&
                _scope.TryResolve(out IActionContextAccessor aca) && aca.ActionContext != null
            )
            {
                _httpContext = hca.HttpContext;
                _urlHelper = new UrlHelper(aca.ActionContext);
            }
        }

        public string Make(string action, string controller, IDictionary<string, string> values)
        {
            if (_urlHelper != null)
            {
                return _urlHelper.Action(action, controller, values, _httpContext.Request.Scheme);
            }

            var url = _configuration.GetValue<string>("App:BaseUrl");

            if (url == null)
            {
                return null;
            }

            return QueryHelpers.AddQueryString(
                $"{url.TrimEnd('/')}/{controller}/{action}",
                values
            );
        }
    }
}