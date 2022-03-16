using CleanIntegration.Core.OracleCRM.Entities;
using CleanIntegration.Core.ReclameAqui.Entities;

namespace CleanIntegration.Functions.ReclameAqui.Mappers
{
    public class TicketMapper
    {
        public static Incident MapToIncident(Ticket ticket)
            => new Incident();
    }
}
