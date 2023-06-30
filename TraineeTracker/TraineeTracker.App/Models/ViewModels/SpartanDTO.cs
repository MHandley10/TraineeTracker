using System.ComponentModel.DataAnnotations;

namespace TraineeTracker.App.Models.ViewModels
{
    public class SpartanDTO
    {
        [StringLength(500)]
        public string? Course { get; set; }
        [StringLength(500)]
        public string? Stream { get; set; }

        public string? UserName { get; set; }
    }
}
