using CleanIntegration.Core.ReclameAqui.Entities;
using CleanIntegration.Core.ReclameAqui.Interfaces;
using CleanIntegration.Infrastructure.ReclameAqui.EFDbContext;
using System.Linq;

namespace CleanIntegration.Infrastructure.ReclameAqui.Repository
{
    public class ExecutionRepository : IExecutionRepository
    {
        private readonly ReclameAquiDbContext _reclameAquiDbContext;

        public ExecutionRepository(ReclameAquiDbContext reclameAquiDbContext)
        {
            _reclameAquiDbContext = reclameAquiDbContext;
        }

        public ExecutionRecord GetLastExecutionRecord()
            => _reclameAquiDbContext.ExecutionRecords.LastOrDefault();
    }
}
