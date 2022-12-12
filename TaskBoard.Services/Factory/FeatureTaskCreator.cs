using TaskBoard.Core.Factory;
using TaskBoard.Core.Models;
using TaskBoard.Services.Services;

namespace TaskBoard.Services.Factory
{
    public class FeatureTaskCreator : TaskFactoryService
    {
        public FeatureTaskCreator(ITaskService taskService) : base(taskService)
        {
        }

        public override AbstractTask Create(TaskDTO taskDTO)
        {
            return new Feature(taskDTO.Id,
                               taskDTO.Name,
                               taskDTO.BoardId,
                               taskDTO.Description,
                               taskDTO.TaskState,
                               taskDTO.ProgrammArea);
        }

        public override List<AbstractTask> GetAll()
        {
            var features = new List<AbstractTask>();
            foreach (ITask task in _taskService.GetAll())
            {
                if (task is Feature feature)
                    features.Add(feature);
            }
            return features;
        }
    }
}