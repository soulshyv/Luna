using Microsoft.Extensions.DependencyInjection;

namespace Luna.Commons.Repositories
{
    public static class RegistrationExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection sc)
        {
            sc.AddScoped<CharacterRepository>();
            sc.AddScoped<RaceRepository>();
            sc.AddScoped<CharacterTypeRepository>();

            return sc;
        }
    }
}