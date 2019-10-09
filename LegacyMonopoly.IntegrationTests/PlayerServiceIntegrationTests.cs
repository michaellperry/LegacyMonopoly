using System;
using Xunit;
using FluentAssertions;
using LegacyMonopoly.DataAccess;
using LegacyMonopoly.Service;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LegacyMonopoly.IntegrationTests
{
    [Collection("Integration test collection")]
    public class PlayerServiceIntegrationTests : IntegrationTestBase
    {
        [Fact]
        public void WhenGameDoesNotExist_ThenPlayerServiceReturnsNull()
        {
            var playerService = GivenPlayerService(
                GivenContext());

            var playerCollection = playerService.LoadPlayers(gameId: 99);

            playerCollection.Should().BeNull();
        }

        [Fact]
        public void WhenGameExistsAndHasNoPlayers_ThenPlayerServiceReturnsEmptyCollection()
        {
            int gameId;
            var playerService = GivenPlayerService(
                GivenContext()
                    .WithGame(out gameId));

            var playerCollection = playerService.LoadPlayers(gameId);

            playerCollection.Should().NotBeNull();
            playerCollection.Players.Should().BeEmpty();
        }

        [Fact]
        public void WhenGameExistsAndHasPlayers_THenPlayerServiceReturnsPlayers()
        {
            int gameId;
            var playerService = GivenPlayerService(
                GivenContext()
                    .WithGameHavingPlayers(out gameId, "Michael", "Kaela"));

            var playerCollection = playerService.LoadPlayers(gameId);

            playerCollection.Players.Count().Should().Be(2);
        }

        private static PlayerService GivenPlayerService(MonopolyContext context)
        {
            return new PlayerService(context);
        }
    }
}
