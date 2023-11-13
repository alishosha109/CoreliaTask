using CoreliaTask.Data;
using CoreliaTask.Interfaces;
using CoreliaTask.Repos;
using CoreliaTask.SignalRHub;
using Microsoft.EntityFrameworkCore;

namespace CoreliaTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddSignalR();

            builder.Services.AddScoped<ICoreliaTaskRepository, CoreliaTaskRepoServices>();

            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.UseEndpoints(endpoints =>
            //{
              //  endpoints.MapHub<TaskHub>("/task-hub");
            //});

            app.MapHub<TaskHub>("task-hub");


            
            app.Run();
        }
    }
}