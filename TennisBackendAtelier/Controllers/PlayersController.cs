using Microsoft.AspNetCore.Mvc;
using TennisBackendAtelier.Interfaces;
using TennisBackendAtelier.Models;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Player>))]
    public IActionResult GetAll()
    {
        var players = _playerService.GetAllSortedByRank();
        return Ok(players);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Player))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var player = _playerService.GetById(id);
        if (player is null)
            return NotFound(new { message = $"Player with id {id} not found" });

        return Ok(player);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Player))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult Create([FromBody] Player player)
    {
        if (_playerService.Exists(player.Id))
            return Conflict(new { message = $"Player with id {player.Id} already exists" });

        var created = _playerService.Add(player);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}
