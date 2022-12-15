using TaskBoard.Core.Constants;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess;

namespace TaskBoard.UnitTests.Mocks
{
    public class MockTaskRepository : ITaskRepository
    {
        public void Add(ITask task)
        {
            throw new NotImplementedException();
        }

        public void ChangeTaskState(int id, TaskState taskState)
        {
            throw new ArgumentOutOfRangeException();
        }

        public void DeleteById(int id)
        {
            throw new ArgumentOutOfRangeException();
        }

        public List<ITask> GetAll()
        {
            return null;
        }

        public ITask GetById(int id)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}