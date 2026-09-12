using TennisBackendAtelier.Models;

namespace TennisBackendAtelier.Tests.Helpers;

public static class PlayerTestFactory
{
    public static Player Create(int id, string firstname, string lastname, int rank, int height = 185)
    {
        return new Player(
            id, firstname, lastname, $"{firstname[0]}.{lastname[..3].ToUpper()}", "M",
            new Country("https://example.com/flag.png", "TST"),
            "https://example.com/photo.png",
            new PlayerData(rank, 1000, 80000, height, 30, new List<int> { 1, 0, 1, 0, 1 }));
    }

    public static List<Player> CreateAll() => new()
    {
        new Player(52, "Novak", "Djokovic", "N.DJO", "M",
            new Country("https://example.com/srb.png", "SRB"),
            "https://example.com/djokovic.png",
            new PlayerData(2, 2542, 80000, 188, 31, new List<int> { 1, 1, 1, 1, 1 })),

        new Player(95, "Venus", "Williams", "V.WIL", "F",
            new Country("https://example.com/usa.png", "USA"),
            "https://example.com/venus.png",
            new PlayerData(52, 1105, 74000, 185, 38, new List<int> { 0, 1, 0, 0, 1 })),

        new Player(65, "Stan", "Wawrinka", "S.WAW", "M",
            new Country("https://example.com/sui.png", "SUI"),
            "https://example.com/wawrinka.png",
            new PlayerData(21, 1784, 81000, 183, 33, new List<int> { 1, 1, 1, 0, 1 })),

        new Player(102, "Serena", "Williams", "S.WIL", "F",
            new Country("https://example.com/usa.png", "USA"),
            "https://example.com/serena.png",
            new PlayerData(10, 3521, 72000, 175, 37, new List<int> { 0, 1, 1, 1, 0 })),

        new Player(17, "Rafael", "Nadal", "R.NAD", "M",
            new Country("https://example.com/esp.png", "ESP"),
            "https://example.com/nadal.png",
            new PlayerData(1, 1982, 85000, 185, 33, new List<int> { 1, 0, 0, 0, 1 }))
    };
}
