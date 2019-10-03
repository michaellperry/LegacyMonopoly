using System;
using Xunit;
using FluentAssertions;
using LegacyMonopoly.Service;
using LegacyMonopoly.Repository;
using LegacyMonopoly.DataAccess;
using System.Linq;

namespace LegacyMonopoly.UnitTests
{
    public class PlayerServiceTests
    {
        [Fact]
        public void WhenGameDoesNotExist_ThenPlayerServiceReturnsNull()
        {
            var playerService = GivenPlayerService(
                GivenRepository());

            var playerCollection = playerService.LoadPlayers(gameId: 99);

            playerCollection.Should().BeNull();
        }

        [Fact]
        public void WhenGameExistsAndHasNoPlayers_ThenPlayerServiceReturnsEmptyCollection()
        {
            var playerService = GivenPlayerService(
                GivenRepository()
                    .WithGame(1));

            var playerCollection = playerService.LoadPlayers(gameId: 1);

            playerCollection.Should().NotBeNull();
            playerCollection.Players.Should().BeEmpty();
        }

        [Fact]
        public void WhenGameExistsAndHasPlayers_THenPlayerServiceReturnsPlayers()
        {
            var playerService = GivenPlayerService(
                GivenRepository()
                    .WithGameHavingPlayers(1, "Michael", "Kaela"));

            var playerCollection = playerService.LoadPlayers(1);

            playerCollection.Players.Count().Should().Be(2);
        }

        private static MemoryPlayerRepository GivenRepository()
        {
            return new MemoryPlayerRepository();
        }

        private static PlayerService GivenPlayerService(MemoryPlayerRepository repository)
        {
            return new PlayerService(repository);
        }
    }
}
