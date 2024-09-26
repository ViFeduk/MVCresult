using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC.Models.Db;
using MVC.Models.Db.Reposytoryes;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogReposytory _blogReposytory;

        public UsersController(IBlogReposytory blogReposytory)
        {
            _blogReposytory = blogReposytory;
        }

        public async Task<IActionResult> Index()
        {
            var ath = await _blogReposytory.GetUsers();
            return View(ath);
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            await _blogReposytory.AddUser(newUser);
            return View(newUser);
        }
        
    }
}
