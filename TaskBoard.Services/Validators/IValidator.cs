using TaskBoard.Core.Models;

namespace TaskBoard.Services.Validators
{
    public interface IValidator
    {
        IEnumerable<bool> Validate(int taskId);
    }
}
