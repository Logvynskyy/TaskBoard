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
        private readonly IValidator<ITask> _taskValidator;

        public TaskService(ITaskRepository taskRepository, IBoardService boardService, IValidator<ITask> taskValidator)
        {
            _taskRepository = taskRepository;
            _boardService = boardService;
            _taskValidator = taskValidator;
        }

        public void Add(ITask task)
        {
            if (!_taskValidator.Validate(task).FirstOrDefault())
                throw new InvalidOperationException("You passed invalid task!");

            _taskRepository.Add(task);
        }

        public bool DeleteById(int id)
        {
            try
            {
                _taskRepository.DeleteById(id);
                return true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public ITask GetById(int id)
        {
            try
            {
                return _taskRepository.GetById(id);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<ITask> GetAll()
        {
            try
            {
                return _taskRepository.GetAll();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }  
        }

        public List<ITask> GetAllOnBoard(int boardId)
        {
            if (boardId < 0 || boardId >= _boardService.GetAll().Count)
                throw new InvalidOperationException("You passed invalid identificator of the board!");
            try
            {
                return GetAll().Where(task => task.BoardId == boardId).ToList();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
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

        public bool ChangeTaskState(int id, TaskState taskState)
        {
            try
            {
                _taskRepository.ChangeTaskState(id, taskState);
                return true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }
    }
}