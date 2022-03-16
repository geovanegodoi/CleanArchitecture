using CleanIntegration.Core.Extensions;
using CleanIntegration.Core.ReclameAqui.Entities;
using CleanIntegration.Core.ReclameAqui.Interfaces;
using System.Collections.Generic;
using System.Linq;
using static CleanIntegration.Core.Extensions.ObjectExtensions;

namespace CleanIntegration.Core.ReclameAqui.Services
{
    public class ReclameAquiService : IReclameAquiService
    {
        private readonly IExecutionRepository    _executionRepository;
        private readonly ITicketRepository       _ticketRepository;
        private readonly IReclameAquiExternalAPI _externalReclameAquiAPI;

        public ReclameAquiService(
            IExecutionRepository    executionRepository,
            ITicketRepository       ticketRepository, 
            IReclameAquiExternalAPI externalReclameAquiAPI)
        {
            _executionRepository    = executionRepository;
            _ticketRepository       = ticketRepository;
            _externalReclameAquiAPI = externalReclameAquiAPI;
        }

        public ICollection<Ticket> GetNewTickets()
        {
            var newTickets      = EmptyCollection<Ticket>();

            var lastExecution   = _executionRepository.GetLastExecutionRecord();

            var returnedTickets = _externalReclameAquiAPI.GetNewTicketsSinceLastExecution(lastExecution);

            if (returnedTickets.HaveItems())
            {
                newTickets = _ticketRepository.FilterOnlyNewTickets(returnedTickets);
            }
            return newTickets.ToList();
        }
    }
}
