using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TraineeTracker.App.Models;

namespace TraineeTracker.App.Data
{
    public class TraineeTrackerContext : IdentityDbContext
    {
        public TraineeTrackerContext(DbContextOptions<TraineeTrackerContext> options)
            : base(options)
        {

        }

        public DbSet<Tracker> TrackerItems { get; set; }

        public DbSet<Spartan> Spartans { get; set; }
    }
}