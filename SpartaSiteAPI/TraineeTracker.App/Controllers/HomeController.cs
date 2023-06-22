using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TraineeTracker.App.Data;
using TraineeTracker.App.Models;

namespace TraineeTracker.App.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TraineeTrackerContext _context;


        public HomeController(ILogger<HomeController> logger, TraineeTrackerContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<string> Role(string id)
        {
            var spartan = await _context.Spartans.Where(t => t.Id == id).FirstOrDefaultAsync();
            var roleID = await _context.UserRoles.Where(t => t.UserId == spartan.Id).Select(t => t.RoleId).FirstOrDefaultAsync();
            var role = await _context.Roles.Where(t => t.Id == roleID).Select(t => t.Name).FirstOrDefaultAsync();

            return role;
        }
    }
}