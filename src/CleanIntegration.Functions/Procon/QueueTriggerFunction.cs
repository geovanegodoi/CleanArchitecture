using System.Text.Json;
using CleanIntegration.Core.Extensions;
using CleanIntegration.Core.OracleCRM.Interfaces;
using CleanIntegration.Core.Procon.Entities;
using CleanIntegration.Functions.Procon.Mappers;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace CleanIntegration.Functions.Procon
{
    public class QueueTriggerFunction
    {
        private readonly IOracleCRMService _oracleCRMService;

        public QueueTriggerFunction(IOracleCRMService oracleCRMService)
        {
            _oracleCRMService = oracleCRMService;
        }

        [FunctionName("Procon_QueueTriggerFunction")]
        public void Run(
            [QueueTrigger("myqueue-items", Connection = "")]string myQueueItem, 
            ILogger log)
        {
            var protocol = DeserializeProtocol(json: myQueueItem);

            if (protocol.IsNotNull())
            {
                var incident = ProtocolMapper.MapToIncident(protocol);

                _oracleCRMService.PublishNewIncident(incident);
            }
        }

        private Protocol DeserializeProtocol(string json)
        {
            var ticket = JsonSerializer.Deserialize<Protocol>(json);

            return ticket ?? new NullProtocol();
        }
    }
}
