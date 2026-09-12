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

    [Fact]
    public void GetById_ExistingId_ReturnsPlayer()
    {
        var player = PlayerTestFactory.Create(17, "Rafael", "Nadal", rank: 1);
        _mockRepository.Setup(r => r.GetById(17)).Returns(player);

        var result = _service.GetById(17);

        Assert.NotNull(result);
        Assert.Equal(17, result!.Id);
        Assert.Equal("Rafael", result.Firstname);
    }

    [Fact]
    public void GetById_NonExistingId_ReturnsNull()
    {
        _mockRepository.Setup(r => r.GetById(999)).Returns((Player?)null);

        var result = _service.GetById(999);

        Assert.Null(result);
    }

    [Fact]
    public void Exists_ExistingId_ReturnsTrue()
    {
        var player = PlayerTestFactory.Create(17, "Rafael", "Nadal", rank: 1);
        _mockRepository.Setup(r => r.GetById(17)).Returns(player);

        Assert.True(_service.Exists(17));
    }

    [Fact]
    public void Exists_NonExistingId_ReturnsFalse()
    {
        _mockRepository.Setup(r => r.GetById(999)).Returns((Player?)null);

        Assert.False(_service.Exists(999));
    }

    [Fact]
    public void Add_CallsRepositoryAndReturnsPlayer()
    {
        var player = PlayerTestFactory.Create(200, "Roger", "Federer", rank: 3);

        var result = _service.Add(player);

        _mockRepository.Verify(r => r.Add(player), Times.Once);
        Assert.Equal(200, result.Id);
        Assert.Equal("Roger", result.Firstname);
    }
}
