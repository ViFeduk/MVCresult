using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using MVC.Models.Db.Reposytoryes;
using static System.Net.WebRequestMethods;
using Microsoft.Extensions.DependencyInjection;

namespace MVC.Models
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public LogMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }
        private void LogConsole(HttpContext context)
        {

            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

        }

        private async Task LogFile(HttpContext context)
        {
            var path = @"C:\Users\Fed_w\source\repos\MVC\MVC\log.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                await writer.WriteLineAsync($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
            }
        }

        private async Task LogDataBase(HttpContext context, ILogRepository logRepository)
        {
            string path = $"http://{context.Request.Host.Value + context.Request.Path}";
            var request = new Request()
            {
                Date = DateTime.Now,
                Url = path
            };
            await logRepository.AddLogs(request);

        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var logRepository = scope.ServiceProvider.GetRequiredService<ILogRepository>();
                await LogDataBase(context, logRepository);
            }
            LogConsole(context);
            await LogFile(context);
           

            await _next.Invoke(context);
        }
    }
}
