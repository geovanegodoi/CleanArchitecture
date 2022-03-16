using CleanIntegration.Core.OracleCRM.Entities;
using CleanIntegration.Core.Procon.Entities;

namespace CleanIntegration.Functions.Procon.Mappers
{
    public class ProtocolMapper
    {
        public static Incident MapToIncident(Protocol protocol)
            => new Incident();
    }
}
