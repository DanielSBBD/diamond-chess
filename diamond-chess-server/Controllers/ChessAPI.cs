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

  //[HttpPost]
  //public IActionResult Register()
  //{
  //  Registration.CreatePlayer();
  //}
}
