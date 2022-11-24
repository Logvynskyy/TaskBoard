using TaskBoard.Core.Models;
using TaskBoard.Core.Constants;

namespace TaskBoard.DataAccess
{
    public class ListTaskRepository : ITaskRepository
    {
        private readonly List<ITask> _tasks = new() { new Feature(0, "feature1", 0, "desc1", TaskState.In_Dev, "blaah"),
                                                        new Bug(1, "bug1", 0, "desc2", TaskState.In_Dev, 1)};

        public void Add(ITask task)
        {
            _tasks.Add(task);
        }

        public void ChangeTaskState(int id, TaskState taskState)
        {
            _tasks[id].TaskState = taskState;
        }

        public void DeleteById(int id)
        {
            _tasks.RemoveAt(id);
        }

        public List<ITask> GetAll()
        {
            return _tasks;
        }

        public ITask GetById(int id)
        {
            return _tasks[id];
        }
    }
}