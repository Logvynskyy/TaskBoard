using TaskBoard.Core.Models;
using TaskBoard.Services.Validators;

namespace TaskBoard.UnitTests.Mocks
{
    public class MockTaskValidator : IValidator<ITask>
    {
        public IEnumerable<bool> Validate(ITask type)
        {
            yield return false;
        }
    }
}