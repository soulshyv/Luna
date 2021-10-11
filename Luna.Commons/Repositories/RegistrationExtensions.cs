using Luna.Commons.Extensions;
using Luna.Commons.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Luna.Commons.Repositories
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection sc)
        {
            sc.AddScopedAsInterfaces<CharacterRepository>();
            sc.AddScoped<CharacterRepository>();
            
            sc.AddScopedAsInterfaces<RaceRepository>();
            sc.AddScoped<RaceRepository>();
            
            sc.AddScopedAsInterfaces<CharacterTypeRepository>();
            sc.AddScoped<CharacterTypeRepository>();
            
            sc.AddScopedAsInterfaces<CustomPropertyTypeRepository>();
            sc.AddScoped<CustomPropertyTypeRepository>();

            return sc;
        }
    }
}