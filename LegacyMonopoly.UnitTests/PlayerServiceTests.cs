using System;
using Xunit;
using FluentAssertions;
using LegacyMonopoly.Service;
using LegacyMonopoly.DataAccess;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LegacyMonopoly.UnitTests
{
    public class PlayerServiceTests
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
            var playerService = GivenPlayerService(
                GivenContext()
                    .WithGame(1));

            var playerCollection = playerService.LoadPlayers(gameId: 1);

            playerCollection.Should().NotBeNull();
            playerCollection.Players.Should().BeEmpty();
        }

        [Fact]
        public void WhenGameExistsAndHasPlayers_THenPlayerServiceReturnsPlayers()
        {
            var playerService = GivenPlayerService(
                GivenContext()
                    .WithGameHavingPlayers(1, "Michael", "Kaela"));

            var playerCollection = playerService.LoadPlayers(1);

            playerCollection.Players.Count().Should().Be(2);
        }

        private static MonopolyContext GivenContext()
        {
            string databaseName = Guid.NewGuid().ToString();

            return new MonopolyContext(new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName)
                .Options);
        }

        private static PlayerService GivenPlayerService(MonopolyContext context)
        {
            return new PlayerService(context);
        }
    }
}
