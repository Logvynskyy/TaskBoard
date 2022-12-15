using TaskBoard.Core.Constants;

namespace TaskBoard.Core.Models;

public interface ITask : IBaseModel
{
    int Id { get; set; }
    string Name { get; set; }
    int BoardId { get; set; }
    TaskType TaskType { get; init; }
}
