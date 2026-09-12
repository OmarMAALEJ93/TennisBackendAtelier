using TennisBackendAtelier.Interfaces;
using TennisBackendAtelier.Models;

namespace TennisBackendAtelier.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IPlayerRepository _repository;

    public StatisticsService(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public Statistics GetStatistics()
    {
        var players = _repository.GetAll();

        return new Statistics(
            BestCountry: GetBestCountry(players),
            AverageBmi: GetAverageBmi(players),
            MedianHeight: GetMedianHeight(players));
    }

    private static string GetBestCountry(List<Player> players)
    {
        return players
            .GroupBy(p => p.Country.Code)
            .Select(g => new
            {
                Country = g.Key,
                WinRatio = g.Sum(p => p.Data.Last.Count(r => r == 1))
                           / (double)g.Sum(p => p.Data.Last.Count)
            })
            .OrderByDescending(c => c.WinRatio)
            .First()
            .Country;
    }

    private static double GetAverageBmi(List<Player> players)
    {
        // Weight in grams → kg, Height in cm → m
        return Math.Round(players.Average(p =>
            (p.Data.Weight / 1000.0) / Math.Pow(p.Data.Height / 100.0, 2)), 2);
    }

    private static double GetMedianHeight(List<Player> players)
    {
        var heights = players.Select(p => p.Data.Height).OrderBy(h => h).ToList();
        int count = heights.Count;

        // Even count: average of the two middle values
        if (count % 2 == 0)
            return (heights[count / 2 - 1] + heights[count / 2]) / 2.0;

        return heights[count / 2];
    }
}
