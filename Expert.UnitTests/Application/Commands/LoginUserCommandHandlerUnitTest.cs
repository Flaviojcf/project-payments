using Expert.Application.Commands.LoginUser;
using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Expert.Domain.Services;
using Moq;

namespace Expert.UnitTests.Application.Commands
{
    [Collection(nameof(LoginUserCommand))]
    public class LoginUserCommandHandlerUnitTest
    {
        [Fact]
        [Trait("Application", "LoginUser - Command")]
        public async Task InputDataIsOk_Executed_ReturnLoginUserOutputModel()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            var loginUserCommand = new LoginUserCommand
            {
                Email = "test@gmail.com",
                Password = "TestPassword"
            };

            var birthDate = new DateTime(2000, 4, 4);
            var user = new User("userName", "test@gmail.com", birthDate, "userPassword", "userRole");

            var loginUserCommandHandler = new LoginUserCommandHandler(authServiceMock.Object, userRepositoryMock.Object);

            authServiceMock.Setup(a => a.ComputeSha256Hash(It.IsAny<string>())).Returns("hashedPassword");
            userRepositoryMock.Setup(r => r.GetUserByEmailAndPasswordAsync(loginUserCommand.Email, "hashedPassword")).ReturnsAsync(user);
            authServiceMock.Setup(a => a.GenerateJwtToken(user.Email, user.Role)).Returns("jwtToken");

            //Act
            var loginUserOutputModel = await loginUserCommandHandler.Handle(loginUserCommand, new CancellationToken());

            //Assert
            Assert.NotNull(loginUserOutputModel);
            Assert.Equal(loginUserCommand.Email, loginUserOutputModel.Email);
            Assert.Equal("jwtToken", loginUserOutputModel.Token);
        }

    }
}
