using CleanIntegration.Core.Procon.Entities;
using System.Collections.Generic;

namespace CleanIntegration.Core.Procon.Interfaces
{
    public interface IProconService
    {
        ICollection<Protocol> GetNewProtocols();
    }
}
