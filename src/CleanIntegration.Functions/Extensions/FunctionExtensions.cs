using Microsoft.Extensions.DependencyInjection;

namespace CleanIntegration.Functions.Extensions
{
    public static class FunctionExtensions
    {
        public static T GetService<T>(this IServiceCollection services)
            => services.BuildServiceProvider().GetRequiredService<T>();
    }
}
