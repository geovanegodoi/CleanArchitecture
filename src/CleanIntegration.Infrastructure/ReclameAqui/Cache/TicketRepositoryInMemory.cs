using CleanIntegration.Core.ReclameAqui.Entities;
using CleanIntegration.Core.ReclameAqui.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;

namespace CleanIntegration.Infrastructure.ReclameAqui.Cache
{
    public class TicketRepositoryInMemory : ITicketRepository
    {
        private readonly IDistributedCache _cache;

        public TicketRepositoryInMemory(IDistributedCache cache)
        {
            _cache = cache;
        }

        public ICollection<Ticket> FilterOnlyNewTickets(ICollection<Ticket> tickets)
        {
            var newTickets = new List<Ticket>();

            foreach (var item in tickets)
            {
                if (TicketNotFound(item))
                {
                    newTickets.Add(item);
                }
            }
            return newTickets;
        }

        private bool TicketNotFound(Ticket ticket)
        {
            var ticketInCache = _cache.GetStringAsync(ticket.Id.ToString()).Result;

            return string.IsNullOrWhiteSpace(ticketInCache);
        }
    }
}
