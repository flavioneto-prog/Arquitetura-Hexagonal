using Bogus;
using Domain.Entities;

namespace Users.Api.Tests.Fakers
{
    public class UserFaker : Faker<User>
    {
        public UserFaker() => CustomInstantiator(f => new User(f.Random.Guid(), f.Name.FullName(), f.Person.Email));
    }
}
