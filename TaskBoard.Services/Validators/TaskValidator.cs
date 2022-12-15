using TaskBoard.Core.Constants;
using TaskBoard.Core.Models;

namespace TaskBoard.Services.Validators
{
    public class TaskValidator : IValidator<ITask>
    {
        public IEnumerable<bool> Validate(ITask task)
        {
            var taskToCheck = (AbstractTask) task;

            if (taskToCheck == null || taskToCheck.Id < 0) yield return false;
            if (string.IsNullOrWhiteSpace(taskToCheck!.Name) || string.IsNullOrWhiteSpace(taskToCheck.Description)) yield return false;
            if (taskToCheck.TaskType.Equals(TaskType.Feature))
                if (string.IsNullOrWhiteSpace((taskToCheck as Feature)!.ProgrammArea)) yield return false;

            if (taskToCheck.TaskType.Equals(TaskType.Bug))
                if ((taskToCheck as Bug)!.Priority <= 0) yield return false;

            yield return true;
        }
    }
}
