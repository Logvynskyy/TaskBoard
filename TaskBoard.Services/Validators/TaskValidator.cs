using TaskBoard.Core.Constants;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess;

namespace TaskBoard.Services.Validators
{
    public class TaskValidator : IValidator<ITask>
    {
        public IEnumerable<bool> Validate(ITask task)
        {
            if (task == null || task.Id < 0) yield return false;
            if (string.IsNullOrWhiteSpace(task!.Name) || string.IsNullOrWhiteSpace(task.Description)) yield return false;
            if (task.TaskType.Equals(TaskType.Feature))
                if (string.IsNullOrWhiteSpace((task as Feature)!.ProgrammArea)) yield return false;

            if (task.TaskType.Equals(TaskType.Bug))
                if ((task as Bug)!.Priority <= 0) yield return false;

            yield return true;
        }
    }
}
