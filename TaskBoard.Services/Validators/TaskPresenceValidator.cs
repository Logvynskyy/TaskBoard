using TaskBoard.DataAccess;

namespace TaskBoard.Services.Validators
{
    public class TaskPresenceValidator : IValidator
    {
        private readonly ITaskRepository _taskRepository;

        public TaskPresenceValidator(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        public IEnumerable<bool> Validate(int taskId)
        {
            yield return taskId >= 0 && taskId < _taskRepository.GetAll().Count;
        }
    }
}
