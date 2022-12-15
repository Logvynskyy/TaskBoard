using TaskBoard.Core.Models;
using TaskBoard.Services.Services;

namespace TaskBoard.UnitTests.Mocks
{
    public class MockBoardService : IBoardService
    {
        public bool Add(Board board)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Board> GetAll()
        {
            return null;
        }

        public Board GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, string name)
        {
            throw new NotImplementedException();
        }
    }
}