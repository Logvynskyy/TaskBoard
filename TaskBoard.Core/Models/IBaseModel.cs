namespace TaskBoard.Core.Models;

public interface IBaseModel
{
    int Id { get; init; }
    string Name { get; set; }
}
