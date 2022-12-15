using TaskBoard.Core.Models;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Core.Constants;
using TaskBoard.Services.Services;
using TaskBoard.Core.Factory;

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

    [HttpGet("Board/{id}/[controller]/types/{taskType}")]
    public IActionResult GetTasksOfSpecificType(int id, TaskType taskType)
    {
        var taskFactory = TaskFactoryService.GetTaskFactoryService(taskType, _taskService);

        if(taskFactory.GetAll().Where(t => t.BoardId == id).ToList().Count == 0)
            return NotFound("You entered wrong board ID!");

        return Ok(taskFactory.GetAll().Where(t => t.BoardId == id));
    }

    [HttpPost("Board/{id}/[controller]/add/{taskType}")]
    public IActionResult AddNewTask([FromBody] TaskDTO task, int id, TaskType taskType)
    {
        task.BoardId = id;
        task.TaskType = taskType;

        var taskFactory = TaskFactoryService.GetTaskFactoryService(taskType, _taskService);

        if (!_taskService.Add(taskFactory.Create(task)))
            return BadRequest("You passed invalid Task!");

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
