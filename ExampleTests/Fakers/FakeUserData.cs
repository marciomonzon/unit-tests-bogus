using Bogus;
using Bogus.DataSets;
using UnitTestsBogus.Models;
using ExampleTests.Extensions;

namespace ExampleTests.Fakers
{
    public static class FakeUserData
    {
        public static User GetFakeUser()
        {
            return new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker)
                .RuleFor(u => u.Name, f => f.Name.FullName(Name.Gender.Male))
                .RuleFor(u => u.Email, f => f.Internet.Email(f.Person.FirstName).ToLower())
                .RuleFor(u => u.Password, f => f.Internet.CustomPassword(8, 10))
                .RuleFor(u => u.DateOfBirth, f => f.Date.PastDateOnly(80));
        }

        public static User GetFakeInvalidUserPassword()
        {
            return new Faker<User>()
                .RuleFor(u => u.Id, f => f.IndexFaker)
                .RuleFor(u => u.Name, f => f.Name.FullName(Name.Gender.Male))
                .RuleFor(u => u.Password, f => f.Internet.CustomPassword(6, 7));
        }
    }
}
