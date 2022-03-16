using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using CleanIntegration.Core.ReclameAqui.Entities;
using CleanIntegration.Core.ReclameAqui.Interfaces;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CleanIntegration.Functions.ReclameAqui
{
    public class TimeTriggerFunction
    {
        private readonly IReclameAquiService _reclameAquiService;

        public TimeTriggerFunction(IReclameAquiService reclameAquiService)
        {
            _reclameAquiService = reclameAquiService;
        }

        [FunctionName("ReclameAqui_TimeTriggerFunction")]
        public async Task Run(
            [TimerTrigger("0 */5 * * * *")]TimerInfo myTimer,
            [Queue("%QueueTickets%", Connection = "Storage:ConnectionString")] CloudQueue queue,
            ILogger log)
        {
            var newTickets = _reclameAquiService.GetNewTickets();

            await SendTicketsToQueue(newTickets, queue);
        }

        private async Task SendTicketsToQueue(ICollection<Ticket> tickets, CloudQueue queue)
        {
            foreach (var ticket in tickets)
            {
                var queueMessage = new CloudQueueMessage(JsonSerializer.Serialize(ticket));

                await queue.AddMessageAsync(queueMessage);
            }
        }
    }
}
