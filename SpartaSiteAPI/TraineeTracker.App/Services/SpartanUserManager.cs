using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TraineeTracker.App.Models;

namespace TraineeTracker.App.Services
{
    public class SpartanUserManager : UserManager<Spartan>
    {
        public SpartanUserManager(IUserStore<Spartan> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<Spartan> passwordHasher, IEnumerable<IUserValidator<Spartan>> userValidators, IEnumerable<IPasswordValidator<Spartan>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<Spartan>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public async Task SaveOtherInputs(Spartan spartan, string about, string education, string experience, string skills, string title, string fname, string lname) 
        {
            spartan.AboutMe = about;
            spartan.Education = education;
            spartan.Experience = experience;
            spartan.Skills = skills;
            spartan.Title = title;
            spartan.FirstName = fname;
            spartan.LastName = lname;
            await UpdateUserAsync(spartan);
        }

        public string GetAboutMe(Spartan user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return user.AboutMe;
        }

        public string GetEducation(Spartan user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return user.Education;
        }

        public string GetExperience(Spartan user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return user.Experience;
        }

        public string GetSkills(Spartan user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return user.Skills;
        }

        internal string GetTitle(Spartan user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return user.Title;
        }

        internal string GetFirstName(Spartan user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return user.FirstName;
        }

        internal string GetLastName(Spartan user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return user.LastName;
        }
    }
}
