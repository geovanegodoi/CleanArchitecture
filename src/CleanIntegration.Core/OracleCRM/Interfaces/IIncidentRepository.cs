using CleanIntegration.Core.OracleCRM.Entities;

namespace CleanIntegration.Core.OracleCRM.Interfaces
{
    public interface IIncidentRepository
    {
        bool HasIncidentBeenSent(Incident incident);

        void StoreIncidentRecord(Incident incident);
    }
}
