using diamond_chess_server.Models;
using Microsoft.AspNetCore.Mvc;

namespace diamond_chess_server.Controllers;

[ApiController]
[Route("[controller]")]
public class ChessAPI : ControllerBase
{
  private static readonly string[] Summaries = new[]
  {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
  };

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
      LoginId = 0
    })
    .ToArray();
  }


  //public IEnumerable<string> GetNames() { }
}
