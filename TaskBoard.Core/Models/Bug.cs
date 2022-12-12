using TaskBoard.Core.Constants;

namespace TaskBoard.Core.Models;

public class Bug : GenericTask
{
    public int Priority { get; set; }

    public Bug(int id, string name, int boardId, string description, TaskState taskState, int priority)
        : base(id, name, boardId, TaskType.Bug, description, taskState)
    {
        this.Priority = priority;
    }
}
