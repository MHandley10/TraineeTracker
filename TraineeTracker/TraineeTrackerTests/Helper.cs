using Microsoft.AspNetCore.Identity;
using Moq;
using TraineeTracker.App.Models;
using TraineeTracker.App.Models.ViewModels;

namespace TraineeTrackerTests
{
    public static class Helper
    {
        public static ServiceResponse<Spartan> GetSpartanServiceResponse()
        {
            var response = new ServiceResponse<Spartan>();
            response.Data = new Spartan
            {
                Id = "Id",
                Email = "Talal@spartaglobal.com",
                EmailConfirmed = true,
                Role = "Trainee"
            };

            return response;
        }
        public static ServiceResponse<T> GetFailedServiceResponse<T>(string message = "")
        {
            var response = new ServiceResponse<T>();
            response.Success = false;
            response.Message = message;
            return response;
        }

        public static ServiceResponse<IEnumerable<TrackerVM>> GetTrackerListServiceResponse()
        {
            var response = new ServiceResponse<IEnumerable<TrackerVM>>();
            response.Data = new List<TrackerVM>
            {
                Mock.Of<TrackerVM>(),
                Mock.Of<TrackerVM>()
            };
            return response;
        }

        public static ServiceResponse<TrackerVM> GetTrackerServiceResponse()
        {
            var response = new ServiceResponse<TrackerVM>();
            response.Data = new TrackerVM() { Title = "temp", Spartan = new SpartanDTO() { UserName = "Talal" } };
            return response;
        }
        public static ServiceResponse<EditTrackerVM> GetEditTrackerServiceResponse()
        {
            var response = new ServiceResponse<EditTrackerVM>();
            response.Data = Mock.Of<EditTrackerVM>();
            return response;
        }
        public static ServiceResponse<DetailsTrackerVM> GetDetailsTrackerServiceResponse()
        {
            var response = new ServiceResponse<DetailsTrackerVM>();
            response.Data = Mock.Of<DetailsTrackerVM>();
            return response;
        }
        public static ServiceResponse<CreateTrackerVM> GetCreateTrackerServiceResponse()
        {
            var response = new ServiceResponse<CreateTrackerVM>();
            response.Data = Mock.Of<CreateTrackerVM>();
            return response;
        }

        public static Mock<UserManager<TUser>> MockUserManager<TUser>(List<TUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<TUser>>();
            var mgr = new Mock<UserManager<TUser>>(store.Object, null, null, null, null, null, null, null, null);
            mgr.Object.UserValidators.Add(new UserValidator<TUser>());
            mgr.Object.PasswordValidators.Add(new PasswordValidator<TUser>());

            mgr.Setup(x => x.DeleteAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);
            mgr.Setup(x => x.CreateAsync(It.IsAny<TUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<TUser, string>((x, y) => ls.Add(x));
            mgr.Setup(x => x.UpdateAsync(It.IsAny<TUser>())).ReturnsAsync(IdentityResult.Success);

            return mgr;
        }

        public static Spartan CreateFakeSpartan(string id)
        {
            var fakeSpartan = new Spartan()
            {
                Id = id,
                UserName = "Robert",
                Course = "Something",
                Stream = "Brook",
                TrackerItems = new List<Tracker>()
            };
            return fakeSpartan;
        }

        public static Tracker CreateFakeTracker(string spartanId)
        {
            var fakeTracker = new Tracker()
            {
                Title = "Week",
                Id = 1,
                Spartan = CreateFakeSpartan(spartanId)
            };
            return fakeTracker;
        }

    }
}
