using System.Threading.Tasks;

namespace MVC.Models.Db.Reposytoryes
{
    public interface ILogRepository
    {
         Task<Request[]> GetAllLogs();
        public Task AddLogs(Request request);

    }
}
