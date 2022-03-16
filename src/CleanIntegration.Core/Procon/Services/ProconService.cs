using CleanIntegration.Core.Procon.Entities;
using CleanIntegration.Core.Procon.Interfaces;
using System.Collections.Generic;

namespace CleanIntegration.Core.Procon.Services
{
    public class ProconService : IProconService
    {
        private readonly EnterpriseConfiguration _enterpriseConfiguration;
        private readonly IProconExternalAPI      _proconExternalAPI;
        private readonly IProtocolRepository     _protocolRepository;

        public ProconService(
            EnterpriseConfiguration enterpriseConfiguration,
            IProconExternalAPI      proconExternalAPI,
            IProtocolRepository     protocolRepository)
        {
            _enterpriseConfiguration = enterpriseConfiguration;
            _proconExternalAPI       = proconExternalAPI;
            _protocolRepository      = protocolRepository;
        }

        public ICollection<Protocol> GetNewProtocols()
        {
            var enterprise      = Enterprise.Factory.NewFromConfig(_enterpriseConfiguration);

            var openedProtocols = _proconExternalAPI.QueryOpenedProtocols(enterprise);

            var newProtocols    = _protocolRepository.FilterOnlyNewProtocols(openedProtocols);

            return newProtocols;
        }
    }
}
