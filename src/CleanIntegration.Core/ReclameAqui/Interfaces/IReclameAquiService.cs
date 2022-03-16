using CleanIntegration.Core.ReclameAqui.Entities;
using System.Collections.Generic;

namespace CleanIntegration.Core.ReclameAqui.Interfaces
{
    public interface IReclameAquiService
    {
        ICollection<Ticket> GetNewTickets();
    }
}
