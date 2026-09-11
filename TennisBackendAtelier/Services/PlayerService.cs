using TennisBackendAtelier.Interfaces;
using TennisBackendAtelier.Models;

namespace TennisBackendAtelier.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _repository;

    public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public List<Player> GetAllSortedByRank()
    {
        return _repository.GetAll()
            .OrderBy(p => p.Data.Rank)
            .ToList();
    }

    public Player? GetById(int id) => _repository.GetById(id);

    public Player Add(Player player)
    {
        _repository.Add(player);
        return player;
    }
}
