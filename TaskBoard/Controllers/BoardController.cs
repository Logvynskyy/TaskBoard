using TaskBoard.Core.Models;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Services.Services;

namespace TaskBoard.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoardController : ControllerBase
{
    private readonly IBoardService _boardService;

    public BoardController(IBoardService boardService)
    {
        this._boardService = boardService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        if (_boardService.GetAll() == null)
            return NotFound("You don't have any boards! Please, create one");
        
        return Ok(_boardService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetBoardById(int id)
    {
        if(_boardService.GetById(id) == null)
            return NotFound("You entered wrong board ID!");

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
        if(!_boardService.DeleteById(id))
            return NotFound("You entered wrong board ID!");

        _boardService.DeleteById(id);

        return Ok(_boardService.GetAll());
    }

    [HttpPatch("edit/{id}")]
    public IActionResult UpdateBoardsName(int id, [FromBody] string name)
    {
        if(!_boardService.Update(id, name))
            return NotFound("You entered wrong board ID!");

        _boardService.Update(id, name);

        return Ok(_boardService.GetById(id));
    }
}
