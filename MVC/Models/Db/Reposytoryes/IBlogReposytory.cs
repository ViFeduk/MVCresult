using System.Threading.Tasks;

namespace MVC.Models.Db.Reposytoryes
{
    public interface IBlogReposytory
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
