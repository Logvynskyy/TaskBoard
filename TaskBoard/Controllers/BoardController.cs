using TaskBoard.Core.Models;
using TaskBoard.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaskBoard.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoardController : Controller
{
    private readonly IBoardService _boardService;

    public BoardController(IBoardService boardService)
    {
        this._boardService = boardService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_boardService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetBoarById(int id)
    {
        return Ok(_boardService.GetById(id));
    }

    [HttpPost("create")]
    public IActionResult CreateNewBoard([FromBody] Board board)
    {
        _boardService.Add(board);

        return Created("api/Board", board);
    }

    [HttpDelete("delete/{id}")]
    public IActionResult DeleteBoard(int id)
    {
        _boardService.DeleteById(id);

        return Ok(_boardService.GetAll());
    }

    [HttpPatch("edit/{id}")]
    public IActionResult UpdateBoardsName(int id, [FromBody] string name)
    {
        _boardService.Update(id, name);
        return Ok(_boardService.GetById(id));
    }
}
