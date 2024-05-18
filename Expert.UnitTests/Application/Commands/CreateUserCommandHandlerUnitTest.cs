using Expert.Application.Commands.CreateUserCommand;
using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Expert.Domain.Services;
using Moq;

namespace Expert.UnitTests.Application.Commands
{
    [Collection(nameof(CreateUserCommandHandler))]
    public class CreateUserCommandHandlerUnitTest
    {
        [Fact]
        [Trait("Application", "User - Command")]
        public async Task InputDataIsOk_Executed_ReturnUserId()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            var createUserCommand = new CreateUserCommand
            {
                BirthDate = DateTime.Now,
                Email = "test@gmail.com",
                FullName = "Test",
                Password = "TestPassword",
                Role = "client"
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

            //Act
            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());


            //Assert
            Assert.True(id >= 0);
            userRepositoryMock.Verify(u => u.AddAsync(It.IsAny<User>()), Times.Once);

        }
    }
}
