using CleanIntegration.Core.ReclameAqui.Entities;
using System.Collections.Generic;

namespace CleanIntegration.Core.ReclameAqui.Interfaces
{
    public interface ITicketRepository
    {
        ICollection<Ticket> FilterOnlyNewTickets(ICollection<Ticket> tickets);
    }
}
