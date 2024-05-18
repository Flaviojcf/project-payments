using Expert.Domain.Entities;

namespace Expert.UnitTests.Domain.Entities
{
    [Collection(nameof(User))]
    public class UserUnitTests
    {
        [Fact]
        [Trait("Domain", "User - Aggregates")]
        public void Instatiate()
        {
            //Arrange
            var birthDate = new DateTime(2000, 4, 4);
            var user = new User("userName", "userEmail@gmail.com", birthDate, "userPassword", "userRole");

            //Act


            //Assert
            Assert.NotNull(user);
            Assert.True(user.Active);
            Assert.Equal(birthDate, user.BirthDate);
            Assert.Null(user.Comments);
            Assert.True(user.CreatedAt <= DateTime.Now && user.CreatedAt >= DateTime.Now.AddSeconds(-10));
            Assert.Equal("userEmail@gmail.com", user.Email);
            Assert.NotNull(user.FreelanceProjects);
            Assert.Equal("userName", user.FullName);
            Assert.Equal(0, user.Id);
            Assert.NotNull(user.OwnedProjects);
            Assert.Equal("userPassword", user.Password);
            Assert.Equal("userRole", user.Role);
            Assert.NotNull(user.UserSkills);
        }
    }
}
