using TaskBoard.Core.Models;

namespace TaskBoard.Services.Validators
{
    public class BoardValidator : IValidator<Board>
    {
        public IEnumerable<bool> Validate(Board board)
        {
            if (board == null) yield return false;
            if (board!.Id < 0) yield return false;
            if (string.IsNullOrWhiteSpace(board.Name)) yield return false;

            yield return true;
        }
    }
}
