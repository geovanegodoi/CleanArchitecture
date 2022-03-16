using CleanIntegration.Core.ReclameAqui.Entities;
using CleanIntegration.Core.ReclameAqui.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace CleanIntegration.Infrastructure.ReclameAqui.ExternalAPI
{
    public class ReclameAquiExternalAPI : IReclameAquiExternalAPI
    {
        private readonly HttpClient _httpClient;

        public ReclameAquiExternalAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public ICollection<Ticket> GetNewTicketsSinceLastExecution(ExecutionRecord lastExecution)
        {
            var httpRequest  = new HttpRequestMessage(method: HttpMethod.Get, requestUri: "");
            
            var httpResponse = _httpClient.SendAsync(httpRequest).Result;

            httpResponse.EnsureSuccessStatusCode();

            return DeserializeContent(httpResponse);
        }

        private ICollection<Ticket> DeserializeContent(HttpResponseMessage httpResponse)
        {
            var contentAsJson = httpResponse.Content.ReadAsStringAsync().Result;
            
            return JsonSerializer.Deserialize<ICollection<Ticket>>(contentAsJson);
        }
    }
}
