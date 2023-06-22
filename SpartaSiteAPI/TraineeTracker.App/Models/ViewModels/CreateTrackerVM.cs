using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TraineeTracker.App.Models.ViewModels
{
    public class CreateTrackerVM
    {
        public string TechnicalSkill { get; set; } = "Partially Skilled";

        public string SpartanSkill { get; set; } = "Partially Skilled";

        [StringLength(50)]
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = null!;

        [StringLength(500)]
        [DisplayName("Start")]
        public string? StartDoingText { get; set; }

        [StringLength(500)]
        [DisplayName("Stop")]
        public string? StopDoingText { get; set; }

        [StringLength(500)]
        [DisplayName("Continue")]
        public string? ContinueDoingText { get; set; }

        [DisplayName("Reviewed")]
        public bool IsReviewed { get; set; }
    }
}