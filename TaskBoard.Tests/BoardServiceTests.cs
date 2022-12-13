using TaskBoard.Core.Models;
using TaskBoard.DataAccess;
using TaskBoard.Services.Services;
using TaskBoard.UnitTests.Mocks;

namespace TaskBoard.UnitTests
{
    [TestFixture]
    public class BoardServiceTests
    {
        private IBoardService _boardService;

        [SetUp]
        public void Setup()
        {
            _boardService = new BoardService(new MockBoardRepository(), new MockBoardValidator());
        }

        //METHODNAME_CONDITION_EXPECTATION

        [Test]
        public void CheckPresence_BoardDoesntExist_Null()
        {
            Assert.That(_boardService.GetById(-1), Is.Null, "When passing invalid Id works as expected");
        }

        [Test]
        public void CheckDeletion_ValidId_True()
        {
            Assert.That(_boardService.DeleteById(0), Is.False);
        }

        [TestCaseSource(nameof(BoardsToTest))]
        public void CheckEdition_IsNotValid_False(Board board)
        {
            Assert.That(_boardService.Update(board.Id, board.Name), Is.False, $"{board.ToString} board is not considered valid");
        }

        static readonly Board[] BoardsToTest =
        {
            new Board(-1, "fsf"),
            new Board(1, ""),
            new Board(1, "   ")
        };
    }
}