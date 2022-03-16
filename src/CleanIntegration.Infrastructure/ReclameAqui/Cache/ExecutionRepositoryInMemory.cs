using CleanIntegration.Core.ReclameAqui.Entities;
using CleanIntegration.Core.ReclameAqui.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CleanIntegration.Infrastructure.ReclameAqui.Cache
{
    public class ExecutionRepositoryInMemory : IExecutionRepository
    {
        private readonly IDistributedCache _cache;

        public ExecutionRepositoryInMemory(IDistributedCache cache)
        {
            _cache = cache;
        }

        public ExecutionRecord GetLastExecutionRecord()
        {
            var returnedJson = _cache.GetStringAsync("LAST_EXECUTION").Result;

            return JsonSerializer.Deserialize<ExecutionRecord>(returnedJson);
        }
    }
}
