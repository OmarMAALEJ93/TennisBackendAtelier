using Microsoft.AspNetCore.Mvc;
using TennisBackendAtelier.Interfaces;

namespace TennisBackendAtelier.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsService _statisticsService;

    public StatisticsController(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [HttpGet]
    public IActionResult GetStatistics()
    {
        var statistics = _statisticsService.GetStatistics();
        return Ok(statistics);
    }
}
