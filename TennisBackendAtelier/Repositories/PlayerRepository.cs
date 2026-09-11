using System.Text.Json;
using TennisBackendAtelier.Interfaces;
using TennisBackendAtelier.Models;

namespace TennisBackendAtelier.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly List<Player> _players;
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public PlayerRepository(IWebHostEnvironment env)
    {
        var path = Path.Combine(env.ContentRootPath, "Data", "headtohead.json");
        var json = File.ReadAllText(path);
        var root = JsonSerializer.Deserialize<PlayersRoot>(json, JsonOptions);
        _players = root?.Players ?? new List<Player>();
    }

    public List<Player> GetAll() => _players.ToList();

    public Player? GetById(int id) => _players.FirstOrDefault(p => p.Id == id);

    public void Add(Player player)
    {
        _players.Add(player);
    }
}
