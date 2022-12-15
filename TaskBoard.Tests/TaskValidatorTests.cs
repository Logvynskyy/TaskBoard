using TaskBoard.Core.Constants;
using TaskBoard.Core.Models;
using TaskBoard.Services.Validators;

namespace TaskBoard.UnitTests
{
    [TestFixture]
    public class TaskValidatorTests {
        private IValidator<ITask> _taskValidator;

        [SetUp]
        public void Setup()
        {
            _taskValidator = new TaskValidator();
        }

        //METHODNAME_CONDITION_EXPECTATION

        [TestCaseSource(nameof(TasksToTest))]
        public void CheckValidation_IsNotValid_False(ITask task)
        {
            Assert.Multiple(() =>
            {
                Assert.That(_taskValidator.Validate(null).FirstOrDefault(), Is.False, $"{task.Name} task is considered valid");
                Assert.That(_taskValidator.Validate(task).FirstOrDefault(), Is.False, $"{task.Name} task is considered valid");
            });
        }

        static readonly ITask[] TasksToTest =
        {
            new GenericTask(0, "", 0, "just a task", TaskState.Approved),
            new Feature(1, "feature1", 0, "desc1 ", TaskState.In_Dev, " "),
            new Bug(2, "bug1", 0, "desc2", TaskState.In_Dev, 0)
        };
    }
}
