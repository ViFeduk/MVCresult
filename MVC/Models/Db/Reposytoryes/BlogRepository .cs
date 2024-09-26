using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MVC.Models.Db.Reposytoryes
{
    public class BlogRepository : IBlogReposytory
    {
        private readonly BlogContext _context;
        public BlogRepository(BlogContext blogContext)
        {
            _context = blogContext;
        }
        public async Task AddUser(User user)
        {
            user.Id = Guid.NewGuid();
            user.JoinDate = DateTime.Now;

            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }
    }
}
