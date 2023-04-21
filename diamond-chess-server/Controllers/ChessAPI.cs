using diamond_chess_server.Models;
using diamond_chess_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace diamond_chess_server.Controllers;

[ApiController]
[Route("[controller]")]
public class ChessAPI : ControllerBase
{
  private readonly ILogger<ChessAPI> _logger;

  public ChessAPI(ILogger<ChessAPI> logger)
  {
    _logger = logger;
  }

  [HttpGet(Name = "Players")]
  public IEnumerable<Player> Get()
  {
    return Enumerable.Range(1, 5).Select(index => new Player
    {
      Id = 0,
      Name = string.Empty,
      Surname = string.Empty,
    })
    .ToArray();
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginDetails loginDetails)
  {
    var success = await LoginService.isValidLogin(loginDetails);
    return success ? CreatedAtAction(null, null, null ,null) : BadRequest();
  }

  [HttpPost]
  public IActionResult SaveGame(GameState game)
  {
    if (GameService.Save(game))
    {
      return CreatedAtAction(nameof(GetGame), new { id = game.Match.Id }, game);
    }
    return BadRequest();
  }

  [HttpGet("matchId")]
  public IActionResult GetGame(int matchId)
  {
    GameState game = GameService.GetGame(matchId);
    if (game.Match?.Id == matchId)
    {
      return Ok(game);
    }
    return BadRequest();
  }
}
