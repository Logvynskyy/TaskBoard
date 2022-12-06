using TaskBoard.Core.Constants;

namespace TaskBoard.Core.Models;

public interface ITask : IBaseModel
{
    new int Id { get; set; }
    new string Name { get; set; }
    int BoardId { get; set; }
    TaskType TaskType { get; init; }
    string Description { get; set; }
    TaskState TaskState { get; set; }
}
