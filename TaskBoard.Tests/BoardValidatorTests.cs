using TaskBoard.Core.Models;
using TaskBoard.Services.Validators;

namespace TaskBoard.UnitTests
{
    [TestFixture]
    public class BoardValidatorTests
    {
        private IValidator<Board> _boardValidator;

        [SetUp]
        public void Setup()
        {
            _boardValidator = new BoardValidator();
        }

        //METHODNAME_CONDITION_EXPECTATION

        [TestCaseSource(nameof(BoardsToTest))]
        public void CheckValidation_IsNotValid_False(Board board)
        {
            Assert.Multiple(() =>
            {
                Assert.That(_boardValidator.Validate(null).FirstOrDefault(), Is.False, $"{board.Name} board is considered valid");
                Assert.That(_boardValidator.Validate(board).FirstOrDefault(), Is.False, $"{board.Name} board is considered valid");
            });
        }

        static readonly Board[] BoardsToTest =
        {
            new Board(-1, "fsf"),
            new Board(1, ""),
            new Board(1, "   ")
        };
    }
}