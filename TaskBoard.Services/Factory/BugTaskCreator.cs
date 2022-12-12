using TaskBoard.Core.Factory;
using TaskBoard.Core.Models;
using TaskBoard.Services.Services;

namespace TaskBoard.Services.Factory
{
    public class BugTaskCreator : TaskFactoryService
    {
        public BugTaskCreator(ITaskService taskService) : base(taskService)
        {
        }

        public override AbstractTask Create(TaskDTO taskDTO)
        {
            return new Bug(taskDTO.Id,
                           taskDTO.Name,
                           taskDTO.BoardId,
                           taskDTO.Description,
                           taskDTO.TaskState,
                           taskDTO.Priority.Value);
        }

        public override List<AbstractTask> GetAll()
        {
            var bugs = new List<AbstractTask>();
            foreach (ITask task in _taskService.GetAll())
            {
                if (task is Bug bug)
                    bugs.Add(bug);
            }
            return bugs;
        }
    }
}