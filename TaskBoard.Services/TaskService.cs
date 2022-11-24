using TaskBoard.Core.Constants;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess;

namespace TaskBoard.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IBoardService _boardService;

        public TaskService(ITaskRepository taskRepository, IBoardService boardService)
        {
            this._taskRepository = taskRepository;
            this._boardService = boardService;
        }

        public void Add(ITask task)
        {
            if (!ValidateTask(task))
                throw new InvalidOperationException("You passed invalid task!");
            if (ValidatePresenceofTheTask(task.Id))
                throw new InvalidOperationException("This task already exists");
            _taskRepository.Add(task);
        }

        public void DeleteById(int id)
        {
            if (!ValidatePresenceofTheTask(id))
                throw new InvalidOperationException("You passed invalid identificator of the task!");
            _taskRepository.DeleteById(id);
        }

        public ITask GetById(int id)
        {
            if (!ValidatePresenceofTheTask(id))
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
            foreach(ITask task in _taskRepository.GetAll())
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
            if(!ValidatePresenceofTheTask(id))
                throw new InvalidOperationException("You passed invalid identificator of the task!");
            _taskRepository.ChangeTaskState(id, taskState);
        }

        private bool ValidateTask(ITask task)
        {
            if (task == null) return false;
            if (task.Id < 0) return false;
            if(task.BoardId < 0 || task.BoardId >= _boardService.GetAll().Count) return false;
            if (string.IsNullOrWhiteSpace(task.Name) || string.IsNullOrWhiteSpace(task.Description)) return false;
            if (task.TaskType.Equals(TaskType.Feature))
                if (string.IsNullOrWhiteSpace((task as Feature)!.ProgrammArea)) return false;

            if (task.TaskType.Equals(TaskType.Bug))
                if ((task as Bug)!.Priority <= 0) return false;

            return true;
        }

        private bool ValidatePresenceofTheTask(int taskId)
        {
            return taskId >= 0 && taskId < GetAll().Count;
        }
    }
}