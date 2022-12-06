using TaskBoard.Core.Models;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Core.Constants;
using TaskBoard.Services.Services;

namespace CustomBoard.Controllers;

[Route("api/")]
[ApiController]
public class TasksController : Controller
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        this._taskService = taskService;
    }

    [HttpGet("[controller]")]
    public IActionResult Index()
    {
        if (_taskService.GetAll() == null)
            return NotFound("You don't have any tasks! Please, create one");

        return Ok(_taskService.GetAll());
    }

    [HttpGet("Board/{id}/[controller]")]
    public IActionResult GetAllTasksOnBoard(int id)
    {        
        if(_taskService.GetAllOnBoard(id) == null)
            return NotFound("You entered wrong board ID!");

        return Ok(_taskService.GetAllOnBoard(id));
    }

    [HttpGet("Board/{id}/[controller]/{taskId}")]
    public IActionResult GetTaskById(int id, int taskId)
    {
        if (_taskService.GetById(id) == null)
            return NotFound("You entered wrong task ID!");

        return Ok(_taskService.GetById(taskId));
    }

    [HttpGet("Board/{id}/[controller]/bugs")]
    public IActionResult GetBugs(int id)
    {
        return Ok(_taskService.GetBugs());
    }

    [HttpGet("Board/{id}/[controller]/features")]
    public IActionResult GetFeatures(int id)
    {
        return Ok(_taskService.GetFeatures());
    }

    [HttpPost("Board/{id}/[controller]/addFeature")]
    public IActionResult AddNewFeature([FromBody] Feature task, int id)
    {
        task.BoardId = id;
        _taskService.Add(task);

        return Created(new string("api/board/" + id + "/Tasks"), task);
    }

    [HttpPost("Board/{id}/[controller]/addBug")]
    public IActionResult AddNewBug([FromBody] Bug task, int id)
    {
        task.BoardId = id;
        _taskService.Add(task);

        return Created(new string("api/board/" + id + "/Tasks"), task);
    }

    [HttpPatch("Board/{boardId}/[controller]/{taskId}/changestate")]
    public IActionResult ChangeTaskState(int boardId, int taskId, [FromBody] TaskState taskState)
    {
        if(!_taskService.ChangeTaskState(taskId, taskState))
            return NotFound("You entered wrong task ID!");

        _taskService.ChangeTaskState(taskId, taskState);

        return Ok(_taskService.GetById(taskId));
    }

    [HttpDelete("Board/{boardId}/[controller]/{taskId}/delete")]
    public IActionResult DeleteBoard(int boardId, int taskId)
    {
        if (!_taskService.DeleteById(taskId))
            return NotFound("You entered wrong task ID!");

        _taskService.DeleteById(taskId);

        return Ok(_taskService.GetAllOnBoard(boardId));
    }
}
