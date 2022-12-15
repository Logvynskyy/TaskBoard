using TaskBoard.Core.Constants;

namespace TaskBoard.Core.Models;

public class Feature : GenericTask
{
    public string ProgrammArea { get; set; }

    public Feature(int id, string name, int boardId, string description, TaskState taskState, string programmArea)
        : base(id, name, boardId, description, taskState, TaskType.Feature)
    {
        this.ProgrammArea = programmArea;
    }
}
