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

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var player = _playerService.GetById(id);
        if (player is null)
            return NotFound(new { message = $"Player with id {id} not found" });

        return Ok(player);
    }
}
