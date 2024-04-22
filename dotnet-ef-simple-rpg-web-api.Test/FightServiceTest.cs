using AutoMapper;
using dotnet_ef_simple_rpg_web_api.Data;
using dotnet_ef_simple_rpg_web_api.Dtos.Character;
using dotnet_ef_simple_rpg_web_api.Dtos.Fight;
using dotnet_ef_simple_rpg_web_api.Models;
using dotnet_ef_simple_rpg_web_api.Services.CharacterService;
using dotnet_ef_simple_rpg_web_api.Services.FightService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace dotnet_ef_simple_rpg_web_api.Test
{
    public class FightServiceTests : IDisposable
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly FightService _fightService;

        public FightServiceTests()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new DataContext(options);

            // Configure AutoMapper if needed
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            _mapper = mapperConfig.CreateMapper();

            _fightService = new FightService(_mapper, _context, null);
        }

        [Fact]
        public async Task AutomaticFight_Returns_FightResult()
        {
            // Arrange
            var characters = new List<Character>
            {
                new Character { Id = 1, Name = "Attacker", HitPoints = 100, Weapons = new List<Weapon>() },
                new Character { Id = 2, Name = "Opponent", HitPoints = 100, Weapons = new List<Weapon>() }
            };

            // Add weapons to the characters
            characters[0].Weapons!.Add(new Weapon { Id = 1, Name = "Sword", Damage = 10 });
            characters[1].Weapons!.Add(new Weapon { Id = 2, Name = "Axe", Damage = 15 });

            // Add skills to the characters
            characters[0].Skills = new List<Skill>
            {
                new Skill { Id = 1, Name = "Fireball", Complexity = 20 }
            };
            characters[1].Skills = new List<Skill>
            {
                new Skill { Id = 2, Name = "Heal", Complexity = 10 }
            };


            _context.Characters.AddRange(characters);
            await _context.SaveChangesAsync();

            var fightRequestDto = new FightRequestDto { CharacterIds = characters.Select(c => c.Id).ToList() };

            // Act
            var response = await _fightService.AutomaticFight(fightRequestDto);

            // Assert
            Assert.True(response.Success);
            // Assert.NotNull(response.Data);
            // Assert.NotNull(response.Data.FightLog);
            // Assert.NotEmpty(response.Data.FightLog);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(101, 300)]
        public async Task GetHighScore_Returns_HighScoreResponse(int attackerId, int opponentId)
        {
            // Arrange
            var characters = new List<Character>
            {
                new Character { Id = attackerId, Name = "Attacker", HitPoints = 100, Victories = 2, Defeats = 1, Fights = 3 },
                new Character { Id = opponentId, Name = "Opponent", HitPoints = 90, Victories = 1, Defeats = 2, Fights = 3 }
            };

            _context.Characters.AddRange(characters);
            await _context.SaveChangesAsync();

            // Act
            var response = await _fightService.GetHighScore();

            // Assert
            Assert.True(response.Success);
            Assert.NotNull(response.Data);
            Assert.NotEmpty(response.Data);

            // assert the winner after the logic is completed
        }

        // Implement other test cases for SkillAttack, AutomaticFight, and GetHighScore methods

        public void Dispose()
        {
            _context.Database.EnsureDeleted(); //del entries between tests
            _context.Dispose();
        }
    }
}
