using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.App.Models.ViewModels;
using TraineeTracker.App.Services;

namespace TraineeTracker.App.Controllers
{
    [Authorize]
    public class TrackersController : Controller
    {
        private readonly ITrackerService _service;

        public TrackersController(ITrackerService service)
        {
            _service = service;
        }

        // GET: Trackers
        /*[Authorize(Roles = "Trainee, Trainer, Admin")]
        public async Task<IActionResult> Index(string? filter = null)
        {
            var user = await _service.GetUserAsync(HttpContext);
            var response = await _service.GetTrackerEntriesAsync(user.Data, _service.GetRole(HttpContext), filter);
            return response.Success ? View(response.Data) : Problem(response.Message);
        }*/

        public async Task<IActionResult> Academy(string? filter = null)
        {
            var user = await _service.GetUserAsync(HttpContext);
            var response = await _service.GetTrackerEntriesAcademyAsync(user.Data, _service.GetRole(HttpContext), filter);
            return response.Success ? View(response.Data) : Problem(response.Message);
        }
        [Authorize(Roles = "Trainee, Trainer, Admin")]
        public async Task<IActionResult> Index(string userName,string? filter = null)
        {
            var user = await _service.GetUserAsync(HttpContext);
            if (_service.GetRole(HttpContext) == "Trainee")
            {
                var traineeResponse = await _service.GetTrackerEntriesAsync(user.Data, _service.GetRole(HttpContext), filter);
                return traineeResponse.Success ? View(traineeResponse.Data) : Problem(traineeResponse.Message);
            }
            var response = await _service.GetTrackerEntryAcademyAsync(user.Data, _service.GetRole(HttpContext), userName);
            return response.Success ? View(response.Data) : Problem(response.Message);
        }

        // GET: Trackers/Details/5
        [Authorize(Roles = "Trainee, Trainer, Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _service.GetUserAsync(HttpContext);
            var response = await _service.GetDetailsAsync(user.Data, id, _service.GetRole(HttpContext));
            return response.Success ? View(response.Data) : Problem(response.Message);
        }

        // GET: Trackers/Create
        [Authorize(Roles = "Trainee")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trackers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainee")]
        public async Task<IActionResult> Create(CreateTrackerVM createTrackerVM)
        {
            var user = await _service.GetUserAsync(HttpContext);
            var response = await _service.CreateTrackerEntriesAsync(user.Data, createTrackerVM);
            return response.Success ? RedirectToAction(nameof(Index)) : View(createTrackerVM);
        }

        // GET: Trackers/Edit/5
        [Authorize(Roles = "Trainee")]
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _service.GetUserAsync(HttpContext);
            var response = await _service.GetEditDetailsAsync(user.Data, id);
            return response.Success ? View(response.Data) : Problem(response.Message);
        }

        // POST: Trackers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainee")]
        public async Task<IActionResult> Edit(int id, EditTrackerVM editTrackerVM)
        {
            var user = await _service.GetUserAsync(HttpContext);
            var response = await _service.EditTrackerEntriesAsync(user.Data, id, editTrackerVM);
            return response.Success ? RedirectToAction(nameof(Index)) : NotFound();
        }

        // POST: Trackers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainee, Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _service.GetUserAsync(HttpContext);
            var response = await _service.DeleteTrackerEntriesAsync(user.Data, id);
            return response.Success ? RedirectToAction("Index", "Trackers", new { userName = response.Data.Spartan.UserName }) : Problem(response.Message);
        }

        [Authorize(Roles = "Trainer, Admin")]
        public async Task<IActionResult> UpdateTrackerReviewed(int id, MarkReviewedVM markReviewedVM)
        {
            var user = await _service.GetUserAsync(HttpContext);
            var response = await _service.UpdateTrackerEntriesCompleteAsync(user.Data, id, markReviewedVM);

            return response.Success ? RedirectToAction("Index", "Trackers", new { userName = response.Data.Spartan.UserName }) : Problem(response.Message);
        }

        [Authorize(Roles = "Trainer, Admin")]
        public async Task<IActionResult> UpdateTrackerGrade(int id, TrackerVM trackerVM, int grade) //Need to get the input text box value...
        {
            var user = await _service.GetUserAsync(HttpContext);
            var response = await _service.UpdateTrackerEntriesGradeAsync(user.Data, id, trackerVM, grade);
            return response.Success ? RedirectToAction("Index", "Trackers", new { userName = response.Data.Spartan.UserName }) : Problem(response.Message);
        }
    }
}
