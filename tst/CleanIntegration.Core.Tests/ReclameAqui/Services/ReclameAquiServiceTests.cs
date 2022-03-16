using Bogus;
using CleanIntegration.Core.ReclameAqui.Entities;
using CleanIntegration.Core.ReclameAqui.Interfaces;
using CleanIntegration.Core.ReclameAqui.Services;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanIntegration.Core.Tests.ReclameAqui.Services
{
    public class ReclameAquiServiceTests
    {
        private readonly IReclameAquiService     sut;
        private readonly IExecutionRepository    executionRepositoryMock;
        private readonly ITicketRepository       ticketRepositoryMock;
        private readonly IReclameAquiExternalAPI externalReclameAquiAPIMock;

        public ReclameAquiServiceTests()
        {
            executionRepositoryMock    = Substitute.For<IExecutionRepository>();
            ticketRepositoryMock       = Substitute.For<ITicketRepository>();
            externalReclameAquiAPIMock = Substitute.For<IReclameAquiExternalAPI>();

            sut = new ReclameAquiService(executionRepositoryMock, ticketRepositoryMock, externalReclameAquiAPIMock);
        }
    
        [Fact]
        public void Should_return_new_tickets_when_received_from_reclame_aqui()
        {
            // Arrange
            var newTickets = GenerateRandomTickets(count: 3);
            externalReclameAquiAPIMock.GetNewTicketsSinceLastExecution(Arg.Any<ExecutionRecord>()).Returns(newTickets);
            ticketRepositoryMock.FilterOnlyNewTickets(newTickets).Returns(newTickets);

            // Act
            var tickets = sut.GetNewTickets();

            // Assert
            tickets.Should().NotBeEmpty();
            tickets.Should().HaveCount(newTickets.Count);
        }

        [Fact]
        public void Should_return_no_tickets_when_received_nothing_from_reclame_aqui()
        {
            // Arrange
            var zeroTickets = GenerateRandomTickets(count: 0);
            externalReclameAquiAPIMock.GetNewTicketsSinceLastExecution(Arg.Any<ExecutionRecord>()).Returns(zeroTickets);

            // Act
            var tickets = sut.GetNewTickets();

            // Assert
            tickets.Should().BeEmpty();
            ticketRepositoryMock.DidNotReceive().FilterOnlyNewTickets(zeroTickets);
        }

        private ICollection<Ticket> GenerateRandomTickets(int count)
            => new Faker<Ticket>().Generate(count);
    }
}
