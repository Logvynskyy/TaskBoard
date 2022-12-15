using TaskBoard.Core.Models;
using TaskBoard.Services.Validators;

namespace TaskBoard.UnitTests.Mocks
{
    public class MockBoardValidator : IValidator<Board>
    {
        public IEnumerable<bool> Validate(Board type)
        {
            yield return false;
        }
    }
}