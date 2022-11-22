namespace TaskBoard.Core.Models;

public class User : IBaseModel
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Email { get; set; }
}
