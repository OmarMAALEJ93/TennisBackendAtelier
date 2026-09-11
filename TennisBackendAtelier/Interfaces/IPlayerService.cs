using TennisBackendAtelier.Models;

namespace TennisBackendAtelier.Interfaces;

public interface IPlayerService
{
    List<Player> GetAllSortedByRank();
    Player? GetById(int id);
    Player Add(Player player);
}
