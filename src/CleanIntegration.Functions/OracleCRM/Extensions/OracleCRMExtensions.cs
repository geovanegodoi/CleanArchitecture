using CleanIntegration.Core.OracleCRM.Interfaces;
using CleanIntegration.Core.OracleCRM.Services;
using CleanIntegration.Functions.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanIntegration.Functions.OracleCRM.Extensions
{
    public static class OracleCRMExtensions
    {
        public static OracleCRMExtensionsConfiguration AddOracleCRMServices(this IServiceCollection services)
        {
            services.AddSingleton<IOracleCRMService, OracleCRMService>();
            services.AddSingleton<IOracleCRMExternalAPI>();
            return new OracleCRMExtensionsConfiguration(services);
        }

        public static void WithDbContextRepository(this OracleCRMExtensionsConfiguration proconExtensionsConfiguration, IConfiguration configuration)
        {
            //services.AddDbContext<ProconDbContext>();
            proconExtensionsConfiguration.Services.AddSingleton<IIncidentRepository>();
        }

        public static void WithInMemoryRepository(this OracleCRMExtensionsConfiguration proconExtensionsConfiguration, IConfiguration configuration)
        {
            proconExtensionsConfiguration.Services.AddSingleton<IIncidentRepository>();
        }
    }

    public class OracleCRMExtensionsConfiguration : ExtensionConfigurationBase
    {
        public OracleCRMExtensionsConfiguration(IServiceCollection services) : base(services) {}
    }
}
