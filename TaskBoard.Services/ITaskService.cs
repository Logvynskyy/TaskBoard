using TaskBoard.Core.Models;

namespace TaskBoard.Services
{
    public interface ITaskService
    {
        ITask GetById(int id);
        List<ITask> GetAll();
        List<ITask> GetAllOnBoard(int boardId);
        void Add(ITask task);
        void DeleteById(int id);
        List<Feature> GetFeatures();
        List<Bug> GetBugs();
    }
}