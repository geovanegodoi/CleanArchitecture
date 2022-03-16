using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanIntegration.Functions.Extensions
{
    public abstract class ExtensionConfigurationBase
    {
        public IServiceCollection Services { get; }

        public ExtensionConfigurationBase(IServiceCollection services)
        {
            Services = services;
        }
    }
}
