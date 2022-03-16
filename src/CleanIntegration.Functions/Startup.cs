using CleanIntegration.Functions.Extensions;
using CleanIntegration.Functions.OracleCRM.Extensions;
using CleanIntegration.Functions.Procon.Extensions;
using CleanIntegration.Functions.ReclameAqui.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanIntegration.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
        {
            builder.ConfigurationBuilder
                   .AddEnvironmentVariables();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services      = builder.Services;
            var configuration = services.GetService<IConfiguration>();

            services.AddReclameAquiServices().WithDbContextRepository(configuration);
            
            services.AddProconServices().WithInMemoryRepository(configuration);

            services.AddOracleCRMServices().WithDbContextRepository(configuration);
        }
    }
}
