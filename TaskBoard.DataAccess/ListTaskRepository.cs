using TaskBoard.Core.Models;
using TaskBoard.Core.Constants;

namespace TaskBoard.DataAccess
{
    public class ListTaskRepository : ITaskRepository
    {
        private readonly List<ITask> _tasks = new() {new GenericTask(0, "generic", 0, TaskType.Maintenance, "just a task", TaskState.Approved),
                                                        new Feature(1, "feature1", 0, "desc1", TaskState.In_Dev, "blaah"),
                                                        new Bug(2, "bug1", 0, "desc2", TaskState.In_Dev, 1)};
        private int _taskId = 3;

        public void Add(ITask task)
        {
            task.Id = _taskId++;
            _tasks.Add(task);
        }

        public void ChangeTaskState(int id, TaskState taskState)
        {
            AbstractTask task = (AbstractTask) _tasks[id];
            task.TaskState = taskState;
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