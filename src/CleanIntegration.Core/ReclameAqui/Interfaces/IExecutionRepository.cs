using CleanIntegration.Core.ReclameAqui.Entities;

namespace CleanIntegration.Core.ReclameAqui.Interfaces
{
    public interface IExecutionRepository
    {
        ExecutionRecord GetLastExecutionRecord();
    }
}
