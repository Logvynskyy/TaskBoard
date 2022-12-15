using TaskBoard.Services.Services;
using TaskBoard.UnitTests.Mocks;
using TaskBoard.Core.Constants;

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
            Assert.That(_taskService.GetAllOnBoard(-1), Is.Null, "When passing invalid Id does still work");
        }

        [Test]
        public void GetById_ValidId_ReturnsTask()
        {
            Assert.That(_taskService.GetById(-1), Is.Null, "When passing invalid Id still works");
        }

        [Test]
        public void CheckEdition_IsNotValid_False()
        {
            Assert.That(_taskService.ChangeTaskState(-1, TaskState.Approved), Is.False, $"Task state still was changed");
        }

        [Test]
        public void CheckDeletion_InvalidId_False()
        {
            Assert.That(_taskService.DeleteById(-1), Is.False);
        }
    }
}
