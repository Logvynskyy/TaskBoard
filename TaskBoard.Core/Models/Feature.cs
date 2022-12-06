using TaskBoard.Core.Constants;

namespace TaskBoard.Core.Models;
public class Feature : ITask
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BoardId { get; set; }
    public TaskType TaskType { get; init; } = TaskType.Feature;
    public string Description { get; set; }
    public TaskState TaskState { get; set; }
    public string ProgrammArea { get; set; }

    public Feature(int id, string name, int boardId, string description, TaskState taskState, string programmArea)
    {
        this.Id = id;
        this.Name = name;
        this.BoardId = boardId;
        this.Description = description;
        this.TaskState = taskState;
        this.ProgrammArea = programmArea;
    }
}
