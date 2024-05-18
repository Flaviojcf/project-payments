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
            Assert.Equal("userName", user.FullName);
            Assert.True(user.Active);
            Assert.Equal("userEmail@gmail.com", user.Email);
            Assert.Equal(birthDate, user.BirthDate);
            Assert.Equal("userPassword", user.Password);
            Assert.Equal("userRole", user.Role);
        }
    }
}
