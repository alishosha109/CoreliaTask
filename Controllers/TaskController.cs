using AutoMapper;
using CoreliaTask.DTO;
using CoreliaTask.Interfaces;
using CoreliaTask.SignalRHub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CoreliaTask.Controllers
{
    public class TaskController : Controller
    {

        private readonly ICoreliaTaskRepository coreliaTaskRepository;
        private readonly IMapper _mapper;
        private readonly IHubContext<TaskHub> _hubContext;

        public TaskController( ICoreliaTaskRepository _coreliaTaskRepository, IMapper mapper, IHubContext<TaskHub> hubContext)
        {
            coreliaTaskRepository = _coreliaTaskRepository;
            _mapper = mapper;
            _hubContext = hubContext;

        }
        public IActionResult Index()
        {
            var tasks = _mapper.Map<List<CoreliaTaskDTO>>(coreliaTaskRepository.GetAllTasks());


            return View(tasks);
        }


        public async void UpdateTask(int taskId)
        {

            coreliaTaskRepository.updateTask(taskId);


            
        }

        
    }
}
