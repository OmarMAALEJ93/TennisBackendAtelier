using Moq;
using TennisBackendAtelier.Interfaces;
using TennisBackendAtelier.Models;
using TennisBackendAtelier.Services;
using TennisBackendAtelier.Tests.Helpers;

namespace TennisBackendAtelier.Tests.Services;

public class StatisticsServiceTests
{
    private readonly Mock<IPlayerRepository> _mockRepository;
    private readonly StatisticsService _service;

    public StatisticsServiceTests()
    {
        _mockRepository = new Mock<IPlayerRepository>();
        _service = new StatisticsService(_mockRepository.Object);
    }

    [Fact]
    public void GetStatistics_BestCountry_ReturnsSRB()
    {
        // SRB: 5/5 = 100%, SUI: 4/5 = 80%, USA: 5/10 = 50%, ESP: 2/5 = 40%
        _mockRepository.Setup(r => r.GetAll()).Returns(PlayerTestFactory.CreateAll());

        var result = _service.GetStatistics();

        Assert.Equal("SRB", result.BestCountry);
    }

    [Fact]
    public void GetStatistics_AverageBmi_IsCorrect()
    {
        // Djokovic: 80/(1.88²) = 22.64, Venus: 74/(1.85²) = 21.62
        // Wawrinka: 81/(1.83²) = 24.18, Serena: 72/(1.75²) = 23.51
        // Nadal: 85/(1.85²) = 24.84 → Average ≈ 23.36
        _mockRepository.Setup(r => r.GetAll()).Returns(PlayerTestFactory.CreateAll());

        var result = _service.GetStatistics();

        Assert.InRange(result.AverageBmi, 23.0, 24.0);
    }

    [Fact]
    public void GetStatistics_MedianHeight_Returns185()
    {
        // Heights sorted: 175, 183, 185, 185, 188 → median = 185
        _mockRepository.Setup(r => r.GetAll()).Returns(PlayerTestFactory.CreateAll());

        var result = _service.GetStatistics();

        Assert.Equal(185, result.MedianHeight);
    }

    [Fact]
    public void GetStatistics_MedianHeight_EvenCount_ReturnsAverage()
    {
        var players = new List<Player>
        {
            PlayerTestFactory.Create(1, "John", "Doe", rank: 1, height: 180),
            PlayerTestFactory.Create(2, "Jane", "Smith", rank: 2, height: 190)
        };
        _mockRepository.Setup(r => r.GetAll()).Returns(players);

        var result = _service.GetStatistics();

        Assert.Equal(185, result.MedianHeight);
    }
}
