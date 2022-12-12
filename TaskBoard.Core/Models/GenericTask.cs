using TaskBoard.Core.Constants;

namespace TaskBoard.Core.Models;
public class GenericTask : AbstractTask
{
    public GenericTask(int id, string name, int boardId, TaskType taskType, string description, TaskState taskState)
        : base(id, name, boardId, TaskType.Maintenance, description, taskState)
    {
    }
}
