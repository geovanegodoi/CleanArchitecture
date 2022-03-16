using CleanIntegration.Core.Procon.Interfaces;
using CleanIntegration.Functions.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanIntegration.Functions.Procon.Extensions
{
    public static class ProconExtensions
    {
        public static ProconExtensionsConfiguration AddProconServices(this IServiceCollection services)
        {
            services.AddSingleton<IProconService>();
            services.AddSingleton<IProconExternalAPI>();
            return new ProconExtensionsConfiguration(services);
        }

        public static void WithDbContextRepository(this ProconExtensionsConfiguration proconExtensionsConfiguration, IConfiguration configuration)
        {
            //services.AddDbContext<ProconDbContext>();
            proconExtensionsConfiguration.Services.AddSingleton<IProtocolRepository>();
        }

        public static void WithInMemoryRepository(this ProconExtensionsConfiguration proconExtensionsConfiguration, IConfiguration configuration)
        {
            proconExtensionsConfiguration.Services.AddSingleton<IProtocolRepository>();
        }
    }

    public class ProconExtensionsConfiguration : ExtensionConfigurationBase
    {
        public ProconExtensionsConfiguration(IServiceCollection services) : base(services) {}
    }
}
