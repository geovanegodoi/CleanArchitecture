using CleanIntegration.Core.OracleCRM.Entities;

namespace CleanIntegration.Core.OracleCRM.Interfaces
{
    public interface IOracleCRMService
    {
        void PublishNewIncident(Incident incident);
    }
}
