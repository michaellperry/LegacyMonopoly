using LegacyMonopoly.DataAccess;
using LegacyMonopoly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LegacyMonopoly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonopolyController : ControllerBase
    {
        private readonly MonopolyContext context;

        public MonopolyController(MonopolyContext context)
        {
            this.context = context;
        }

        [HttpPost("game")]
        public IActionResult BeginGame(BeginGameRepresentation gameRequest)
        {
            Game game = new Game();
            game.Players = gameRequest.PlayerNames
                .Select(name => new Player { Name = name, Money = 1500 })
                .ToList();
            context.Games.Add(game);
            context.SaveChanges();
            return base.Created(
                Url.Action("GetGame", new { id = game.GameId }),
                RepresentGame(game));
        }

        [HttpGet("game/{id}")]
        public IActionResult GetGame(int id)
        {
            var game = context.Games
                .Include(g => g.Players)
                .ThenInclude(p => p.Deeds)
                .ThenInclude(d => d.Property.PropertyGroup)
                .Where(g => g.GameId == id)
                .SingleOrDefault();
            if (game == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(RepresentGame(game));
            }
        }

        [HttpPost("game/{gameId}/player/{playerId}/deed")]
        public IActionResult PurchaseProperty(int gameId, int playerId, PurchasePropertyRepresentation purchaseProperty)
        {
            var player = context.Players
                .Where(p => p.GameId == gameId && p.PlayerId == playerId)
                .SingleOrDefault();
            if (player == null)
            {
                return NotFound();
            }

            var property = context.Properties
                .Include(p => p.PropertyGroup)
                .Where(p => p.PropertyId == purchaseProperty.PropertyId)
                .SingleOrDefault();
            if (property == null)
            {
                return BadRequest();
            }

            if (player.Money < property.Price)
            {
                return BadRequest();
            }

            player.Money -= property.Price;
            var deed = new Deed
            {
                Property = property
            };
            player.Deeds.Add(deed);
            context.SaveChanges();

            return Created(
                Url.Action("GetDeed", new { gameId, playerId, deedId = deed.DeedId }),
                RepresentDeed(deed));
        }

        [HttpGet("game/{gameId}/player/{playerId}/deed/{deedId}")]
        public IActionResult GetDeed(int gameId, int playerId, int deedId)
        {
            var deed = context.Deeds
                .Include(d => d.Property)
                .Include(d => d.Property.PropertyGroup)
                .Where(d => d.Player.GameId == gameId && d.PlayerId == playerId && d.DeedId == deedId)
                .SingleOrDefault();
            if (deed == null)
            {
                return NotFound();
            }

            return Ok(RepresentDeed(deed));
        }

        [HttpPatch("game/{gameId}/player/{playerId}")]
        public IActionResult MovePlayer(int gameId, int playerId, MovePlayerRequest movePlayerRequest)
        {
            var player = context.Players
                .Where(p => p.GameId == gameId && p.PlayerId == playerId)
                .SingleOrDefault();
            if (player == null)
            {
                return NotFound();
            }

            var deed = context.Deeds
                .Include(d => d.Property)
                .Include(d => d.Player)
                .Where(d => d.Property.Position == movePlayerRequest.Position
                    && d.Player.GameId == gameId)
                .SingleOrDefault();
            if (deed != null)
            {
                if (deed.PlayerId != playerId)
                {
                    decimal rent = 0.0m;

                    var owner = deed.Player;
                    var propertiesInGroup = context.Properties
                        .Where(p => p.PropertyGroupId == deed.Property.PropertyGroupId)
                        .Select(p => p.PropertyId)
                        .ToList();
                    var deedsOfProperties = context.Deeds
                        .Where(d => d.Player.GameId == gameId
                            && propertiesInGroup.Contains(d.PropertyId))
                        .ToList();
                    if (deedsOfProperties.Count == propertiesInGroup.Count
                        && deedsOfProperties.All(d => d.PlayerId == deed.PlayerId))
                    {
                        rent = deed.Property.Rent * 2m;
                    }
                    else
                    {
                        rent = deed.Property.Rent;
                    }

                    player.Money -= rent;
                    owner.Money += rent;

                    context.SaveChanges();
                }
            }

            return Ok(RepresentPlayer(player));
        }

        private GameRepresentation RepresentGame(Game game)
        {
            return new GameRepresentation
            {
                Players = game.Players.Select(p => RepresentPlayer(p)).ToList()
            };
        }

        private PlayerRepresentation RepresentPlayer(Player player)
        {
            return new PlayerRepresentation
            {
                Name = player.Name,
                Money = player.Money,
                HrefDeeds = Url.Action("PurchaseProperty", new { gameId = player.GameId, playerId = player.PlayerId }),
                Deeds = player.Deeds.Select(d => RepresentDeed(d)).ToList()
            };
        }

        private DeedRepresentation RepresentDeed(Deed deed)
        {
            return new DeedRepresentation
            {
                Name = deed.Property.Name,
                Color = deed.Property.PropertyGroup.Color,
                Rent = deed.Property.Rent,
                Position = deed.Property.Position
            };
        }
    }
}