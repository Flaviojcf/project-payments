using Expert.Application.Queries.GetUser;
using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Moq;

namespace Expert.UnitTests.Application.Queries
{
    [Collection(nameof(GetUserByIdQueryHandler))]
    public class GetUserByIdQueryHandlerUnitTest
    {

        [Fact]
        [Trait("Application", "User - Query")]
        public async Task UserExist_Executed_ReturnUserOutputModel()
        {
            // Arrange
            var user = new User("clientFullName", "client@example.com", new DateTime(1990, 1, 1), "client_password", "Client");

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(u => u.GetByIdAsync(user.Id)).ReturnsAsync(user);

            var getUserByIdQuery = new GetUserByIdQuery(user.Id);
            var getUserByIdQueryHandler = new GetUserByIdQueryHandler(userRepositoryMock.Object);

            // Act
            var userOutputModel = await getUserByIdQueryHandler.Handle(getUserByIdQuery, new CancellationToken());

            // Assert
            Assert.NotNull(userOutputModel);
            userRepositoryMock.Verify(p => p.GetByIdAsync(user.Id), Times.Once);
        }
    }
}
