using TaskBoard.Core.Models;
using TaskBoard.DataAccess;
using TaskBoard.Services.Services;
using TaskBoard.Services.Validators;
using TaskBoard.UnitTests.Mocks;

namespace TaskBoard.UnitTests
{
    [TestFixture]
    public class TaskServiceTests
    {
        private IBoardService _boardService;

        private ITaskService _taskService;

        [SetUp]
        public void Setup()
        {
            _boardService = new BoardService(new MockBoardRepository(), new MockBoardValidator());

            _taskService = new TaskService(new MockTaskRepository(), _boardService, new MockTaskValidator());
        }

        //METHODNAME_CONDITION_EXPECTATION

        [Test]
        public void GetOnBoard_InvalidBoardId_Null()
        {
            Assert.That(_taskService.GetAllOnBoard(-1), Is.Null, "When passing invalid Id works as expected");
        }

        [Test]
        public void GetById_ValidId_ReturnsTask()
        {
            Assert.That(_taskService.GetById(-1), Is.Null, "When passing invalid Id works as expected");
        }





        static readonly ITask[] TasksToTest =
        {
            //new Board(-1, "fsf"),
            //new Board(1, ""),
            //new Board(1, "   ")
        };
    }
}
