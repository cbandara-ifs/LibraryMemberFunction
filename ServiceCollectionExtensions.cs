using LibraryMemberFunction.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LibraryMemberFunction
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseSettings = new DatabaseSettings();
            var databaseSettingsConfigSection = configuration.GetSection(nameof(DatabaseSettings));
            databaseSettingsConfigSection.Bind(databaseSettings);
            services.Configure<DatabaseSettings>(databaseSettingsConfigSection);

            services.AddSingleton(provider => provider.GetRequiredService<IOptions<DatabaseSettings>>().Value);

            return services;
        }
    }
}
