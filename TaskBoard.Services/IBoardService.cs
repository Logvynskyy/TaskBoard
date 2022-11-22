using TaskBoard.Core.Models;

namespace TaskBoard.Services
{
    public interface IBoardService
    {
        Board GetById(int id);
        List<Board> GetAll();
        void Add(Board board);
        void Update(int id, string name);
        void DeleteById(int id);
        void Delete(Board board);
        bool ValidatePresenceofTheBoard(int id);
    }
}