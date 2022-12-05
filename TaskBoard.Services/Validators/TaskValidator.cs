using TaskBoard.Core.Constants;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess;

namespace TaskBoard.Services.Validators
{
    public class TaskValidator : IValidator
    {
        private readonly ITaskRepository _taskRepository;

        public TaskValidator(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        public IEnumerable<bool> Validate(int taskId)
        {
            var task = GetTask(taskId);
            if (task == null || task.Id < 0) yield return false;
            if (string.IsNullOrWhiteSpace(task!.Name) || string.IsNullOrWhiteSpace(task.Description)) yield return false;
            if (task.TaskType.Equals(TaskType.Feature))
                if (string.IsNullOrWhiteSpace((task as Feature)!.ProgrammArea)) yield return false;

            if (task.TaskType.Equals(TaskType.Bug))
                if ((task as Bug)!.Priority <= 0) yield return false;

            yield return true;
        }

        private ITask GetTask(int id)
        {
            return _taskRepository.GetById(id);
        }
    }
}
