using TaskBoard.Core.Models;

namespace TaskBoard.Services.Validators
{
    public class TaskValidators : IValidator<ITask>
    {
        public readonly IEnumerable<IValidator<ITask>> Validators;

        public TaskValidators()
        {
            Validators = new List<IValidator<ITask>>()
            {
                new TaskValidator(),
            };
        }

        public IEnumerable<bool> Validate(ITask type)
        {
            return Validators.SelectMany(validator => validator.Validate(type));
        }
    }
}
