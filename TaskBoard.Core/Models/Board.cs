namespace TaskBoard.Core.Models;
public class Board : IBaseModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Board(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
}
