using CleanIntegration.Core.ReclameAqui.Entities;
using CleanIntegration.Core.ReclameAqui.Interfaces;
using CleanIntegration.Infrastructure.ReclameAqui.EFDbContext;
using System.Collections.Generic;
using System.Linq;

namespace CleanIntegration.Infrastructure.ReclameAqui.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ReclameAquiDbContext _reclameAquiDbContext;

        public TicketRepository(ReclameAquiDbContext reclameAquiDbContext)
        {
            _reclameAquiDbContext = reclameAquiDbContext;
        }

        public ICollection<Ticket> FilterOnlyNewTickets(ICollection<Ticket> tickets)
        {
            var ticketsInDb = _reclameAquiDbContext.Tickets;

            return tickets.Except(ticketsInDb).ToList();
        }
    }
}
