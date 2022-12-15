using TaskBoard.Core.Models;
using TaskBoard.DataAccess;

namespace TaskBoard.UnitTests.Mocks
{
    public class MockBoardRepository : IBoardRepository
    {
        public void Add(Board board)
        {
            throw new InvalidOperationException();
        }

        public void DeleteById(int id)
        {
            throw new ArgumentOutOfRangeException();
        }

        public List<Board> GetAll()
        {
            return new List<Board>();
        }

        public Board GetById(int id)
        {
            throw new ArgumentOutOfRangeException();
        }

        public void Update(int id, string name)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}