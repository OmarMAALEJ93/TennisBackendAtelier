using TennisBackendAtelier.Models;

namespace TennisBackendAtelier.Interfaces;

public interface IPlayerRepository
{
    List<Player> GetAll();
    Player? GetById(int id);
    void Add(Player player);
}
