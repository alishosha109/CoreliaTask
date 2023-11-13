using CoreliaTask.Models;

namespace CoreliaTask.Interfaces
{
    public interface ICoreliaTaskRepository
    {

        List<CTask> GetAllTasks();

        void updateTask(int taskid);

    }
}
