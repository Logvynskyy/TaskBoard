using TaskBoard.Core.Constants;
using TaskBoard.Core.Models;

namespace TaskBoard.Services.Services
{
    public interface ITaskService
    {
        ITask GetById(int id);
        List<ITask> GetAll();
        List<ITask> GetAllOnBoard(int boardId);
        bool Add(ITask task);
        bool DeleteById(int id);
        bool ChangeTaskState(int id, TaskState taskState);
    }
}