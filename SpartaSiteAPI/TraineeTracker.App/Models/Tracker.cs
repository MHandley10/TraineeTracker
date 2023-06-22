using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeTracker.App.Models
{
    public class Tracker
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Title is required")]
        [DisplayName("Week")]
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

        public string TechnicalSkill { get; set; } = "Partially Skilled";

        public string SpartanSkill { get; set; } = "Partially Skilled";

        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public Spartan? Spartan { get; set; }

        [ValidateNever]
        [ForeignKey("Spartan")]
        public string SpartanId { get; set; } = null!;

        [DisplayName("Grade")]
        [Range(0, 100)]
        public int PercentGrade { get; set; } = 0;

    }
}
