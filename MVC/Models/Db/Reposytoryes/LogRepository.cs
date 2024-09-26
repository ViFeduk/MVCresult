using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MVC.Models.Db.Reposytoryes
{
    public class LogRepository:ILogRepository
    {
        private readonly BlogContext _context;
        public LogRepository(BlogContext blogContext)
        {
            _context = blogContext; 
        }

        public async Task AddLogs(Request request)
        {
            request.Id = Guid.NewGuid();
            

            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);
            

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetAllLogs()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
