using TaskBoard.Core.Models;
using TaskBoard.Services;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Core.Constants;

namespace CustomBoard.Controllers;

[Route("api/")]
[ApiController]
public class TasksController : Controller
{
    private readonly ITaskService _taskService;
    private readonly IBoardService _boardService;

    public TasksController(ITaskService taskService, IBoardService boardService)
    {
        this._taskService = taskService;
        this._boardService = boardService;
    }

    [HttpGet("[controller]")]
    public IActionResult Index()
    {
        return Ok(_taskService.GetAll());
    }

    [HttpGet("Board/{id}/[controller]")]
    public IActionResult GetAllTasksOnBoard(int id)
    {
        if (!ValidateBoard(id))
            return BadRequest("You entered invalid id of the board!");
        
        return Ok(_taskService.GetAllOnBoard(id));
    }

    [HttpGet("Board/{id}/[controller]/{taskId}")]
    public IActionResult GetTaskById(int id, int taskId)
    {
        if (!ValidateBoard(id))
            return BadRequest("You entered invalid id of the board!");

        return Ok(_taskService.GetById(taskId));
    }

    [HttpGet("Board/{id}/[controller]/bugs")]
    public IActionResult GetBugs(int id)
    {
        if (!ValidateBoard(id))
            return BadRequest("You entered invalid id of the board!");

        return Ok(_taskService.GetBugs());
    }

    [HttpGet("Board/{id}/[controller]/features")]
    public IActionResult GetFeatures(int id)
    {
        if (!ValidateBoard(id))
            return BadRequest("You entered invalid id of the board!");

        return Ok(_taskService.GetFeatures());
    }

    [HttpPost("Board/{id}/[controller]/addFeature")]
    public IActionResult AddNewFeature([FromBody] Feature task, int id)
    {
        if (!ValidateBoard(id))
            return BadRequest("You entered invalid id of the board!");
        
        task.BoardId = id;
        _taskService.Add(task);

        return Created(new string("api/board/" + id + "/Tasks"), task);
    }

    [HttpPost("Board/{id}/[controller]/addBug")]
    public IActionResult AddNewBug([FromBody] Bug task, int id)
    {
        if (!ValidateBoard(id))
            return BadRequest("You entered invalid id of the board!");

        task.BoardId = id;
        _taskService.Add(task);

        return Created(new string("api/board/" + id + "/Tasks"), task);
    }

    [HttpPatch("Board/{boardId}/[controller]/{taskId}/changestate")]
    public IActionResult ChangeTaskState(int boardId, int taskId, [FromBody] TaskState taskState)
    {
        if (!ValidateBoard(boardId))
            return BadRequest("You entered invalid id of the board!");

        _taskService.ChangeTaskState(taskId, taskState);
        return Ok(_taskService.GetById(taskId));
    }

    [HttpDelete("Board/{boardId}/[controller]/{taskId}/delete")]
    public IActionResult DeleteBoard(int boardId, int taskId)
    {
        if (!ValidateBoard(boardId))
            return BadRequest("You entered invalid id of the board!");

        _taskService.DeleteById(taskId);

        return Ok(_taskService.GetAllOnBoard(boardId));
    }

    private bool ValidateBoard(int id)
    {
        return _boardService.ValidatePresenceofTheBoard(id);
    }
}
