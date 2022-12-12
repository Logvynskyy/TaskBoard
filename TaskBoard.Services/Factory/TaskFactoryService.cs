using TaskBoard.Core.Constants;
using TaskBoard.Core.Models;
using TaskBoard.Services.Factory;
using TaskBoard.Services.Services;

namespace TaskBoard.Core.Factory
{
    public abstract class TaskFactoryService
    {
        protected readonly ITaskService _taskService;

        public TaskFactoryService(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public abstract AbstractTask Create(TaskDTO taskDTO);
        public abstract List<AbstractTask> GetAll();

        public static TaskFactoryService GetTaskFactoryService(TaskType taskType, ITaskService taskService) {
            switch (taskType)
            {
                case TaskType.Maintenance: {
                        return new GenericTaskCreator(taskService);
                    }
                case TaskType.Feature: {
                        return new FeatureTaskCreator(taskService);
                    }
                case TaskType.Bug: {
                        return new BugTaskCreator(taskService);
                    }
                default: throw new NotImplementedException("You passed invalid task type!");
            }
        }
    }
}
