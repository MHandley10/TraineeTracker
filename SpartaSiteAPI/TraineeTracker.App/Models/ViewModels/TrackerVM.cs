using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TraineeTracker.App.Models.ViewModels
{
    public class TrackerVM
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
        public int PercentGrade { get; set; }

        [DisplayName("Reviewed")]
        public bool IsReviewed { get; set; }

        public SpartanDTO? Spartan { get; set; }
    }
}