using TaskBoard.Core.Constants;

namespace TaskBoard.Core.Models;

public abstract class AbstractTask : ITask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BoardId { get; set; }
    public TaskType TaskType { get; init; }
    public string Description { get; set; }
    public TaskState TaskState { get; set; }

    public AbstractTask(int id, string name, int boardId, TaskType taskType, string description, TaskState taskState)
    {
        Id = id;
        Name = name;
        BoardId = boardId;
        TaskType = taskType;
        Description = description;
        TaskState = taskState;
    }
}
