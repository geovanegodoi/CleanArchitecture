using CleanIntegration.Core.OracleCRM.Entities;
using CleanIntegration.Core.OracleCRM.Interfaces;
using CleanIntegration.Core.OracleCRM.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanIntegration.Core.Tests.OracleCRM.Services
{
    public class OracleCRMServiceTests
    {
        private readonly IOracleCRMService sut;

        private readonly IIncidentRepository   incidentRepositoryMock;
        private readonly IOracleCRMExternalAPI oracleCRMExternalAPIMock;

        public OracleCRMServiceTests()
        {
            incidentRepositoryMock   = Substitute.For<IIncidentRepository>();
            oracleCRMExternalAPIMock = Substitute.For<IOracleCRMExternalAPI>();

            sut = new OracleCRMService(incidentRepositoryMock, oracleCRMExternalAPIMock);
        }

        [Fact]
        public void Should_publish_only_new_incidents()
        {
            // Arrange
            var newIncident = new Incident();
            incidentRepositoryMock.HasIncidentBeenSent(newIncident).Returns(false);

            // Act
            sut.PublishNewIncident(newIncident);

            // Assert
            oracleCRMExternalAPIMock.Received(requiredNumberOfCalls: 1).PostNewIncident(newIncident);
            incidentRepositoryMock.Received(requiredNumberOfCalls: 1).StoreIncidentRecord(newIncident);
        }

        [Fact]
        public void Should_not_publish_already_sent_incidents()
        {
            // Arrange
            var newIncident = new Incident();
            incidentRepositoryMock.HasIncidentBeenSent(newIncident).Returns(true);

            // Act
            sut.PublishNewIncident(newIncident);

            // Assert
            oracleCRMExternalAPIMock.DidNotReceive().PostNewIncident(newIncident);
            incidentRepositoryMock.DidNotReceive().StoreIncidentRecord(newIncident);
        }
    }
}
