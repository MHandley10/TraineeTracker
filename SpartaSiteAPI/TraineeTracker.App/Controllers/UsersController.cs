using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TraineeTracker.App.Data;
using TraineeTracker.App.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TraineeTracker.App.Migrations;
using Microsoft.EntityFrameworkCore;

namespace TraineeTracker.App.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly TraineeTrackerContext _context;
        private readonly UserManager<Spartan> _userManager;
        private readonly IMapper _mapper;
        

        public UsersController(TraineeTrackerContext context, UserManager<Spartan> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }

        

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var spartans = _userManager.Users.ToList();
            return View(spartans);

        }

        // GET: Trackers/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string? id)
        {
            var spartan = _userManager.Users.Where(s => s.Id == id).FirstOrDefault();
            return View(spartan);
        }

        // GET: Trackers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trackers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(Spartan spartan, string p)
        {
            Regex regex1 = new Regex("[!@#$%^&*()_+\\-=\\[\\]{};':\"\\\\|,.<>/?]");
            Regex regex2 = new Regex("[0123456789]");
            if (p.Length < 8 || !regex1.IsMatch(p) || !regex2.IsMatch(p))
            {
                return Problem("Password must be 8 characters minimum and contain at least one special character and one number.");
            }

            string userName = spartan.Email;
            int index = userName.IndexOf('@');
            userName = userName.Remove(index);
            spartan.UserName = userName[0].ToString().ToUpper() + userName.Substring(1);
            
            spartan.EmailConfirmed = true;

            _userManager
                .CreateAsync(spartan, p)
                .GetAwaiter()
                .GetResult();

            var roleStore = new RoleStore<IdentityRole>(_context);

            var roleQuery = _context.Roles.Where(r => r.Name == spartan.Role).Select(r => r.Id);

            _context.UserRoles.Add(new IdentityUserRole<string>()
            {
                UserId = _userManager.GetUserIdAsync(spartan).Result,
                RoleId = roleQuery.First()

            }) ;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Trackers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string? id)
        {
            var spartan = await _userManager.FindByIdAsync(id);

            if (spartan == null)
            {
                return Problem();
            }
            else
            {
                return View(spartan);
            }
        }

        // POST: Trackers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, Spartan spartan)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            if (user.Role == "Admin" && admins.Count <= 1)
            {
                return Problem("There must be a minimum of 1 admin user");
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, user.Role);
                await _userManager.AddToRoleAsync(user, spartan.Role);
                user.Role = spartan.Role;
				
			}
            user.UserName = spartan.UserName;
            user.Course = spartan.Course;
            user.Stream = spartan.Stream;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        // POST: Trackers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }

    }
}