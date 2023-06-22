using System.ComponentModel.DataAnnotations;

namespace TraineeTracker.App.Models.ViewModels;

public class TrackerAcademyVM
{
    public int Id { get; set; }

    [StringLength(500)]
    public string? Course { get; set; }

    [StringLength(500)]
    public string? Stream { get; set; } = "Developer!";

    public Spartan? Spartan { get; set; }
}
