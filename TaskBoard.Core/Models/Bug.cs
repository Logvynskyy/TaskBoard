using TaskBoard.Core.Constants;

namespace TaskBoard.Core.Models;

public class Bug : ITask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TaskType TaskType { get; init; } = TaskType.Bug;
    public string Description { get; set; }
    public TaskState TaskState { get; set; }
    public int Priority { get; set; }
    public int BoardId { get; set; }

    public Bug(int id, string name, int boardid, string description, TaskState taskState, int priority)
    {
        this.Id = id;
        this.Name = name;
        this.BoardId = boardid;
        this.Description = description;
        this.TaskState = taskState;
        this.Priority = priority;
    }
}
