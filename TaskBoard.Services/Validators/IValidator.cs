using TaskBoard.Core.Models;

namespace TaskBoard.Services.Validators
{
    public interface IValidator<T>
    {
        IEnumerable<bool> Validate(T type);
    }
}
