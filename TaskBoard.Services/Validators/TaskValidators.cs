using TaskBoard.Core.Models;
using TaskBoard.DataAccess;

namespace TaskBoard.Services.Validators
{
    public class TaskValidators : IValidator
    {
        public readonly IEnumerable<IValidator> Validators;
        private readonly ITaskRepository _taskRepository;

        public TaskValidators(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
            Validators = new List<IValidator>()
            {
                new TaskValidator(_taskRepository),
                new TaskPresenceValidator(_taskRepository)
            };
        }

        public IEnumerable<bool> Validate(int taskId)
        {
            return Validators.SelectMany(validator => validator.Validate(taskId));
        }
    }
}
