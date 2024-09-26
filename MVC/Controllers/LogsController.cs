using Microsoft.AspNetCore.Mvc;
using MVC.Models.Db.Reposytoryes;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogRepository _logRepository;
        public LogsController(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task <IActionResult> Index()
        {
            var logs = await _logRepository.GetAllLogs();
            return View(logs);
        }
    }
}
