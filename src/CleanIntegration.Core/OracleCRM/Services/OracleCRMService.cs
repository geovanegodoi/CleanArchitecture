using CleanIntegration.Core.OracleCRM.Entities;
using CleanIntegration.Core.OracleCRM.Interfaces;

namespace CleanIntegration.Core.OracleCRM.Services
{
    public class OracleCRMService : IOracleCRMService
    {
        private readonly IIncidentRepository   _incidentRepository;
        private readonly IOracleCRMExternalAPI _oracleCRMExternalAPI;

        public OracleCRMService(
            IIncidentRepository   incidentRepository, 
            IOracleCRMExternalAPI oracleCRMExternalAPI)
        {
            _incidentRepository   = incidentRepository;
            _oracleCRMExternalAPI = oracleCRMExternalAPI;
        }

        public void PublishNewIncident(Incident incident)
        {
            var alreadySent = _incidentRepository.HasIncidentBeenSent(incident);
            
            if (!alreadySent)
            {
                _oracleCRMExternalAPI.PostNewIncident(incident);

                _incidentRepository.StoreIncidentRecord(incident);
            }
        }
    }
}
