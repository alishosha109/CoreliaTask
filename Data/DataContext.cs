using CoreliaTask.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreliaTask.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }



        public DbSet<CTask> Tasks { get; set; }



    }
}
