using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TraineeTracker.App.Models.ViewModels
{
    public class DetailsTrackerVM
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Title is required")]
        [DisplayName("Week")]
        public string Title { get; set; } = null!;

        [DisplayName("Technical Skill")]
        public string TechnicalSkill { get; set; } = "Partially Skilled";

        [DisplayName("Soft Skill")]
        public string SpartanSkill { get; set; } = "Partially Skilled";

        [DisplayName("Grade")]
        [Range(0, 100)]
        public int PercentGrade { get; set; } = 0;

        [DisplayName("Reviewed")]
        public bool IsReviewed { get; set; }

        [StringLength(500)]
        [DisplayName("Start")]
        public string? StartDoingText { get; set; }

        [StringLength(500)]
        [DisplayName("Stop")]
        public string? StopDoingText { get; set; }

        [StringLength(500)]
        [DisplayName("Continue")]
        public string? ContinueDoingText { get; set; }

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
