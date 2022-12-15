using TaskBoard.Core.Constants;

namespace TaskBoard.Core.Models;
public class GenericTask : AbstractTask
{
    public GenericTask(int id, string name, int boardId, string description, TaskState taskState, TaskType taskType = TaskType.Maintenance)
        : base(id, name, boardId, taskType, description, taskState)
    {
    }
}
