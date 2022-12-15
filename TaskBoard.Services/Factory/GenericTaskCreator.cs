using TaskBoard.Core.Constants;
using TaskBoard.Core.Factory;
using TaskBoard.Core.Models;
using TaskBoard.Services.Services;

namespace TaskBoard.Services.Factory
{
    public class GenericTaskCreator : TaskFactoryService
    {
        public GenericTaskCreator(ITaskService taskService) : base(taskService)
        {
        }

        public override AbstractTask Create(TaskDTO taskDTO)
        {
            return new GenericTask(taskDTO.Id,
                                   taskDTO.Name,
                                   taskDTO.BoardId,
                                   taskDTO.Description,
                                   taskDTO.TaskState);
        }

        public override List<AbstractTask> GetAll()
        {
            var generics = new List<AbstractTask>();
            foreach (ITask task in _taskService.GetAll())
            {
                if (task is GenericTask genericTask)
                    generics.Add(genericTask);
            }
            return generics;
        }
    }
}