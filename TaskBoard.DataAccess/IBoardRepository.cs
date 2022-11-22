using TaskBoard.Core.Models;

namespace TaskBoard.DataAccess
{
    public interface IBoardRepository
    {
        Board GetById(int id);
        List<Board> GetAll();
        void Add(Board board);
        void Update(int id, string name);
        void DeleteById(int id);
        void Delete(Board board);
    }
}