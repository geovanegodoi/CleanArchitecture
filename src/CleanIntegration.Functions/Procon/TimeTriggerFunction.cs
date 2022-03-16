using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using CleanIntegration.Core.Procon.Entities;
using CleanIntegration.Core.Procon.Interfaces;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CleanIntegration.Functions.Procon
{
    public class TimeTriggerFunction
    {
        private readonly IProconService _proconService;

        public TimeTriggerFunction(IProconService proconService)
        {
            _proconService = proconService;
        }

        [FunctionName("Procon_TimeTriggerFunction")]
        public async Task Run(
            [TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,
            [Queue("%QueueTickets%", Connection = "Storage:ConnectionString")] CloudQueue queue,
            ILogger log)
        {
            var newProtocols = _proconService.GetNewProtocols();

            await SendProtocolsToQueue(newProtocols, queue);
        }

        private async Task SendProtocolsToQueue(ICollection<Protocol> protocols, CloudQueue queue)
        {
            foreach (var protocol in protocols)
            {
                var queueMessage = new CloudQueueMessage(JsonSerializer.Serialize(protocol));

                await queue.AddMessageAsync(queueMessage);
            }
        }
    }
}
