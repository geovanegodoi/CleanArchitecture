using System.Text.Json;
using CleanIntegration.Core.Extensions;
using CleanIntegration.Core.OracleCRM.Interfaces;
using CleanIntegration.Core.ReclameAqui.Entities;
using CleanIntegration.Functions.ReclameAqui.Mappers;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CleanIntegration.Functions.ReclameAqui
{
    public class QueueTriggerFunction
    {
        private readonly IOracleCRMService _oracleCRMService;

        public QueueTriggerFunction(IOracleCRMService oracleCRMService)
        {
            _oracleCRMService = oracleCRMService;
        }

        [FunctionName("ReclameAqui_QueueTriggerFunction")]
        public void Run(
            [QueueTrigger("myqueue-items", Connection = "")]string myQueueItem, 
            ILogger log)
        {
            var ticket = DeserializeTicket(json: myQueueItem);

            if (ticket.IsNotNull())
            {
                var incident = TicketMapper.MapToIncident(ticket);

                _oracleCRMService.PublishNewIncident(incident);
            }
        }

        private Ticket DeserializeTicket(string json)
        {
            var ticket = JsonSerializer.Deserialize<Ticket>(json);

            return ticket ?? new NullTicket();
        }
    }
}
