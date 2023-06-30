using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TraineeTracker.App.Models;

namespace TraineeTracker.App.Data
{
    public class SeedData
    {
        public static void Initialise(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<TraineeTrackerContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Spartan>>();
            var roleStore = new RoleStore<IdentityRole>(context);


            if (context.Spartans.Any())
            {
                context.Spartans.RemoveRange(context.Spartans);
                context.TrackerItems.RemoveRange(context.TrackerItems);
                context.UserRoles.RemoveRange(context.UserRoles);
                context.Roles.RemoveRange(context.Roles);
                context.SaveChanges();
            }


            var trainer = new IdentityRole
            {
                Name = "Trainer",
                NormalizedName = "TRAINER"
            };
            var trainee = new IdentityRole
            {
                Name = "Trainee",
                NormalizedName = "TRAINEE"
            };
            var admin = new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };


            roleStore
              .CreateAsync(trainer)
              .GetAwaiter()
              .GetResult();
            roleStore
                .CreateAsync(trainee)
                .GetAwaiter()
                .GetResult();
            roleStore
                .CreateAsync(admin)
                .GetAwaiter()
                .GetResult();

            var nish = new Spartan
            {
                UserName = "Nish",
                Email = "Nish@spartaglobal.com",
                EmailConfirmed = true,
                Role = "Admin"
            };
            var peter = new Spartan
            {
                UserName = "Peter",
                Email = "Peter@spartaglobal.com",
                EmailConfirmed = true,
                Role = "Trainer"
            };
            var matt = new Spartan
            {
                UserName = "Matt",
                Email = "Matt@spartaglobal.com",
                EmailConfirmed = true,
                Course = "C-Blunt"
            };
            var danielle = new Spartan
            {
                UserName = "Danielle",
                Email = "Danielle@spartaglobal.com",
                EmailConfirmed = true,
                Course = "Java"
            };
            var jacob = new Spartan
            {
                UserName = "Jacob",
                Email = "Jacob@spartaglobal.com",
                EmailConfirmed = false,
                Course = "C#"
            };
            var danyal = new Spartan
            {
                UserName = "Danyal",
                Email = "Danyal@spartaglobal.com",
                EmailConfirmed = true,
                Course = "C#"
            };

            userManager
                .CreateAsync(nish, "Password1!")
                .GetAwaiter()
                .GetResult();
            userManager
                .CreateAsync(peter, "Password1!")
                .GetAwaiter()
                .GetResult();
            userManager
                .CreateAsync(matt, "Password1!")
                .GetAwaiter()
                .GetResult();
            userManager
                .CreateAsync(danielle, "Password1!")
                .GetAwaiter()
                .GetResult();
            userManager
                .CreateAsync(jacob, "Password1!")
                .GetAwaiter()
                .GetResult();
            userManager
                .CreateAsync(danyal, "Password1!")
                .GetAwaiter()
                .GetResult();

            context.UserRoles.AddRange(new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(nish).Result,
                    RoleId = roleStore.GetRoleIdAsync(admin).Result
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(peter).Result,
                    RoleId = roleStore.GetRoleIdAsync(trainer).Result
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(matt).Result,
                    RoleId = roleStore.GetRoleIdAsync(trainee).Result
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(danielle).Result,
                    RoleId = roleStore.GetRoleIdAsync(trainee).Result
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(jacob).Result,
                    RoleId = roleStore.GetRoleIdAsync(trainee).Result
                },
                new IdentityUserRole<string>
                {
                    UserId = userManager.GetUserIdAsync(danyal).Result,
                    RoleId = roleStore.GetRoleIdAsync(trainee).Result
                }

            });



            context.TrackerItems.AddRange(
                new Tracker
                {
                    Title = "Week 1",
                    StartDoingText = "Start it",
                    StopDoingText = "Stop it",
                    ContinueDoingText = "Continue it",
                    IsReviewed = false,
                    Spartan = matt,
                    PercentGrade = 75
                },
                new Tracker
                {
                    Title = "Week 2",
                    StartDoingText = "Hello",
                    StopDoingText = "Goodbye",
                    ContinueDoingText = "...",
                    IsReviewed = true,
                    Spartan = matt,
                    PercentGrade = 80
                },
                new Tracker
                {
                    Title = "Week 1",
                    StartDoingText = "Sleep",
                    StopDoingText = "Working",
                    ContinueDoingText = "Doing well",
                    IsReviewed = true,
                    Spartan = danielle,
                    PercentGrade = 75
                },
                new Tracker
                {
                    Title = "Week 2",
                    StartDoingText = "start",
                    StopDoingText = "Stop",
                    ContinueDoingText = "Continue",
                    IsReviewed = false,
                    Spartan = danielle,
                    PercentGrade = 80
                },
                new Tracker
                {
                    Title = "Week 1",
                    StartDoingText = "Sleep",
                    StopDoingText = "Working",
                    ContinueDoingText = "Doing well",
                    IsReviewed = true,
                    Spartan = jacob,
                    PercentGrade = 75
                },
                new Tracker
                {
                    Title = "Week 2",
                    StartDoingText = "start",
                    StopDoingText = "Stop",
                    ContinueDoingText = "Continue",
                    IsReviewed = false,
                    Spartan = jacob,
                    PercentGrade = 80
                },
                new Tracker
                {
                    Title = "Week 3",
                    StartDoingText = "start",
                    StopDoingText = "Stop",
                    ContinueDoingText = "Continue",
                    IsReviewed = false,
                    Spartan = jacob,
                    PercentGrade = 69
                },
                new Tracker
                {
                    Title = "Week 1",
                    StartDoingText = "start",
                    StopDoingText = "Stop",
                    ContinueDoingText = "Continue",
                    IsReviewed = false,
                    Spartan = danyal,
                    PercentGrade = 80
                },
                new Tracker
                {
                    Title = "Week 2",
                    StartDoingText = "start",
                    StopDoingText = "Stop",
                    ContinueDoingText = "Continue",
                    IsReviewed = false,
                    Spartan = danyal,
                    PercentGrade = 75
                },
                new Tracker
                {
                    Title = "Week 3",
                    StartDoingText = "start",
                    StopDoingText = "Stop",
                    ContinueDoingText = "Continue",
                    IsReviewed = false,
                    Spartan = danyal,
                    PercentGrade = 80
                }
            );
            context.SaveChanges();
        }
    }
}