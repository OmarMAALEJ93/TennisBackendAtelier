using Microsoft.AspNetCore.Mvc;
using TennisBackendAtelier.Interfaces;

namespace TennisBackendAtelier.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayersController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayersController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var players = _playerService.GetAllSortedByRank();
        return Ok(players);
    }
}
