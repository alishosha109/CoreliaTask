using CoreliaTask.Data;
using CoreliaTask.Interfaces;
using CoreliaTask.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreliaTask.Repos
{
    public class CoreliaTaskRepoServices : ICoreliaTaskRepository
    {
        public DataContext Context { get; set; }


        public CoreliaTaskRepoServices(DataContext _context)
        {
            Context = _context;
        }

        List<CTask> ICoreliaTaskRepository.GetAllTasks()
        {
            return Context.Tasks.ToList();
        }

        void ICoreliaTaskRepository.updateTask(int taskid)
        {
            var task = Context.Tasks.FirstOrDefault(t => t.TaskId == taskid);
            task.UpdateTimes++;
            Context.SaveChanges();
        }
    }
}
