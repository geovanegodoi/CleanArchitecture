using CleanIntegration.Core.ReclameAqui.Interfaces;
using CleanIntegration.Core.ReclameAqui.Services;
using CleanIntegration.Functions.Extensions;
using CleanIntegration.Infrastructure.ReclameAqui.Cache;
using CleanIntegration.Infrastructure.ReclameAqui.EFDbContext;
using CleanIntegration.Infrastructure.ReclameAqui.ExternalAPI;
using CleanIntegration.Infrastructure.ReclameAqui.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanIntegration.Functions.ReclameAqui.Extensions
{
    public static class ReclameAquiExtensions
    {
        public static ReclameAquiExtensionsConfiguration AddReclameAquiServices(this IServiceCollection services)
        {
            services.AddSingleton<IReclameAquiService, ReclameAquiService>();
            services.AddSingleton<IReclameAquiExternalAPI, ReclameAquiExternalAPI>();
            return new ReclameAquiExtensionsConfiguration(services);
        }

        public static void WithDbContextRepository(this ReclameAquiExtensionsConfiguration reclameAquiExtensionsConfiguration, IConfiguration configuration)
        {
            reclameAquiExtensionsConfiguration.Services.AddDbContext<ReclameAquiDbContext>();
            reclameAquiExtensionsConfiguration.Services.AddSingleton<IExecutionRepository, ExecutionRepository>();
            reclameAquiExtensionsConfiguration.Services.AddSingleton<ITicketRepository, TicketRepository>();
        }

        public static void WithInMemoryRepository(this ReclameAquiExtensionsConfiguration reclameAquiExtensionsConfiguration, IConfiguration configuration)
        {
            reclameAquiExtensionsConfiguration.Services.AddSingleton<IExecutionRepository, ExecutionRepositoryInMemory>();
            reclameAquiExtensionsConfiguration.Services.AddSingleton<ITicketRepository, TicketRepositoryInMemory>();
        }
    }

    public class ReclameAquiExtensionsConfiguration : ExtensionConfigurationBase
    {
        public ReclameAquiExtensionsConfiguration(IServiceCollection services) : base(services) {}
    }
}
