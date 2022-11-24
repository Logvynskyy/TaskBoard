using TaskBoard.Core.Constants;
using TaskBoard.Core.Models;

namespace TaskBoard.DataAccess
{
    public interface ITaskRepository
    {
        ITask GetById(int id);
        List<ITask> GetAll();
        void Add(ITask task);
        void DeleteById(int id);
        void ChangeTaskState(int id, TaskState taskState);
    }
}