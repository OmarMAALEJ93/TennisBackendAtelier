using Moq;
using TennisBackendAtelier.Interfaces;
using TennisBackendAtelier.Models;
using TennisBackendAtelier.Services;
using TennisBackendAtelier.Tests.Helpers;

namespace TennisBackendAtelier.Tests.Services;

public class PlayerServiceTests
{
    private readonly Mock<IPlayerRepository> _mockRepository;
    private readonly PlayerService _service;

    public PlayerServiceTests()
    {
        _mockRepository = new Mock<IPlayerRepository>();
        _service = new PlayerService(_mockRepository.Object);
    }

    [Fact]
    public void GetAllSortedByRank_ReturnsPlayersSortedByRankAscending()
    {
        var players = new List<Player>
        {
            PlayerTestFactory.Create(1, "Stan", "Wawrinka", rank: 21),
            PlayerTestFactory.Create(2, "Rafael", "Nadal", rank: 1),
            PlayerTestFactory.Create(3, "Novak", "Djokovic", rank: 2)
        };
        _mockRepository.Setup(r => r.GetAll()).Returns(players);

        var result = _service.GetAllSortedByRank();

        Assert.Equal(1, result[0].Data.Rank);
        Assert.Equal(2, result[1].Data.Rank);
        Assert.Equal(21, result[2].Data.Rank);
    }

    [Fact]
    public void GetAllSortedByRank_ReturnsAllPlayers()
    {
        var players = new List<Player>
        {
            PlayerTestFactory.Create(1, "Rafael", "Nadal", rank: 1),
            PlayerTestFactory.Create(2, "Novak", "Djokovic", rank: 2)
        };
        _mockRepository.Setup(r => r.GetAll()).Returns(players);

        var result = _service.GetAllSortedByRank();

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void GetAllSortedByRank_EmptyList_ReturnsEmpty()
    {
        _mockRepository.Setup(r => r.GetAll()).Returns(new List<Player>());

        var result = _service.GetAllSortedByRank();

        Assert.Empty(result);
    }
}
