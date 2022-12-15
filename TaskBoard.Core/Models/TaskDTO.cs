using TaskBoard.Core.Constants;

namespace TaskBoard.Core.Models
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BoardId { get; set; }
        public TaskType TaskType { get; set; }
        public string Description { get; set; }
        public TaskState TaskState { get; set; }
        public int? Priority { get; set; }
        public string? ProgrammArea { get; set; }

        public TaskDTO(int id, string name, int boardId, TaskType taskType, string description, TaskState taskState, int? priority, string? programmArea)
        {
            Id = id;
            Name = name;
            BoardId = boardId;
            TaskType = taskType;
            Description = description;
            TaskState = taskState;
            Priority = priority;
            ProgrammArea = programmArea;
        }
    }
}
