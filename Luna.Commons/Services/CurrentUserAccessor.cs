using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Luna.Commons.Authentication;
using Microsoft.AspNetCore.Http;

namespace Luna.Commons.Services
{
    public class CurrentUserAccessor
    {
        private ILifetimeScope Scope { get; set; }
        
        private IHttpContextAccessor _httpContextAccessor;
        private IHttpContextAccessor HttpContextAccessor =>
            _httpContextAccessor ?? (Scope.TryResolve<IHttpContextAccessor>(out var accessor) ? 
                _httpContextAccessor = accessor : null);

        private LunaUserManager _userManager;
        private LunaUserManager UserManager => _userManager ??= Scope.Resolve<LunaUserManager>();

        public CurrentUserAccessor(ILifetimeScope scope)
        {
            Scope = scope;
        }

        private ClaimsPrincipal GetClaimsPrincipalFromHttpContext()
        {
            return HttpContextAccessor?.HttpContext?.User;
        }

        public async Task<ClaimsIdentity> GetClaimsIdentity()
        {
            return (ClaimsIdentity) (await GetClaimsPrincipal()).Identity;
        }

        public async Task<ClaimsPrincipal> GetClaimsPrincipal()
        {
            return GetClaimsPrincipalFromHttpContext();
        }

        public async Task<Guid> GetUserId()
        {
            var userId = GetClaimsPrincipalFromHttpContext()?.FindFirstValue(ClaimTypes.NameIdentifier);

            return !string.IsNullOrWhiteSpace(userId) ? new Guid(userId) : Guid.Empty;
        }

        public async Task<string> GetUserName()
        {
            return GetClaimsPrincipalFromHttpContext()?.FindFirstValue(ClaimTypes.Name);
        }
    }
}