using TraineeTracker.App.Models;
using TraineeTracker.App.Models.ViewModels;

namespace TraineeTracker.App.Services
{
    public interface ITrackerService
    {
        Task<ServiceResponse<IEnumerable<TrackerVM>>> GetTrackerEntriesAsync(Spartan? spartan, string role = "Trainee", string filter = null);
        Task<ServiceResponse<IEnumerable<SpartanDTO>>> GetTrackerEntriesAcademyAsync(Spartan? spartan, string role, string filter);
        Task<ServiceResponse<IEnumerable<TrackerVM>>> GetTrackerEntryAcademyAsync(Spartan? spartan, string role, string userName);
        Task<ServiceResponse<DetailsTrackerVM>> GetDetailsAsync(Spartan? spartan, int? id, string role = "Trainee");
        Task<ServiceResponse<CreateTrackerVM>> CreateTrackerEntriesAsync(Spartan? spartan, CreateTrackerVM trackerCreateVM);
        Task<ServiceResponse<EditTrackerVM>> EditTrackerEntriesAsync(Spartan? spartan, int? id, EditTrackerVM trackerDetailsVM);
        Task<ServiceResponse<TrackerVM>> UpdateTrackerEntriesCompleteAsync(Spartan? spartan, int id, MarkReviewedVM markCompleteVM, string role = "Trainee");
        Task<ServiceResponse<TrackerVM>> UpdateTrackerEntriesGradeAsync(Spartan? spartan, int id, TrackerVM trackerVM, int grade);
        Task<ServiceResponse<TrackerVM>> DeleteTrackerEntriesAsync(Spartan? spartan, int? id);
        Task<ServiceResponse<EditTrackerVM>> GetEditDetailsAsync(Spartan? spartan, int? id);
        Task<ServiceResponse<Spartan>> GetUserAsync(HttpContext httpContext);
        Task<string> GetSpartanOwnerAsync(int? id);
        bool TrackerEntriesExists(int id);
        string GetRole(HttpContext httpContext);
    }
}
