using TennisBackendAtelier.Models;

namespace TennisBackendAtelier.Tests.Helpers;

public static class PlayerTestFactory
{
    public static Player Create(int id, string firstname, string lastname, int rank)
    {
        return new Player(
            id, firstname, lastname, $"{firstname[0]}.{lastname[..3].ToUpper()}", "M",
            new Country("https://example.com/flag.png", "TST"),
            "https://example.com/photo.png",
            new PlayerData(rank, 1000, 80000, 185, 30, new List<int> { 1, 0, 1, 0, 1 }));
    }
}
