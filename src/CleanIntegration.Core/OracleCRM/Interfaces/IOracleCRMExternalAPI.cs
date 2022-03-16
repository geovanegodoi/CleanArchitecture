using CleanIntegration.Core.OracleCRM.Entities;

namespace CleanIntegration.Core.OracleCRM.Interfaces
{
    public interface IOracleCRMExternalAPI
    {
        void PostNewIncident(Incident incident);
    }
}
