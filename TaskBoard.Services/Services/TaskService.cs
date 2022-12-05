using TaskBoard.Core.Constants;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess;
using TaskBoard.Services.Validators;

namespace TaskBoard.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IBoardService _boardService;
        private readonly IValidator _taskValidator;

        public TaskService(ITaskRepository taskRepository, IBoardService boardService, IValidator taskValidator)
        {
            _taskRepository = taskRepository;
            _boardService = boardService;
            _taskValidator = taskValidator;
        }

        public void Add(ITask task)
        {
            if (!_taskValidator.Validate(task.Id).FirstOrDefault())
                throw new InvalidOperationException("You passed invalid task!");
            if (_taskValidator.Validate(task.Id).FirstOrDefault())
                throw new InvalidOperationException("This task already exists");
            _taskRepository.Add(task);
        }

        public void DeleteById(int id)
        {
            if (!_taskValidator.Validate(id).FirstOrDefault())
                throw new InvalidOperationException("You passed invalid identificator of the task!");
            _taskRepository.DeleteById(id);
        }

        public ITask GetById(int id)
        {
            if (!_taskValidator.Validate(id).FirstOrDefault())
                throw new InvalidOperationException("You passed invalid identificator of the task!");
            return _taskRepository.GetById(id);
        }

        public List<ITask> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public List<ITask> GetAllOnBoard(int boardId)
        {
            if (boardId < 0 || boardId >= _boardService.GetAll().Count)
                throw new InvalidOperationException("You passed invalid identificator of the board!");
            return GetAll().Where(task => task.BoardId == boardId).ToList();
        }

        public List<Bug> GetBugs()
        {
            var bugs = new List<Bug>();
            foreach (ITask task in _taskRepository.GetAll())
            {
                if (task is Bug bug)
                    bugs.Add(bug);
            }
            return bugs;
        }

        public List<Feature> GetFeatures()
        {
            var features = new List<Feature>();
            foreach (ITask task in _taskRepository.GetAll())
            {
                if (task is Feature feature)
                    features.Add(feature);
            }
            return features;
        }

        public void ChangeTaskState(int id, TaskState taskState)
        {
            if (!_taskValidator.Validate(id).FirstOrDefault())
                throw new InvalidOperationException("You passed invalid identificator of the task!");
            _taskRepository.ChangeTaskState(id, taskState);
        }
    }
}