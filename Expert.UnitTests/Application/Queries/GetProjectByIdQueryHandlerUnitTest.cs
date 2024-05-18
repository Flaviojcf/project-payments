using Expert.Application.Queries.GetProjectById;
using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Moq;

namespace Expert.UnitTests.Application.Queries
{
    [Collection(nameof(GetProjectByIdQueryHandler))]
    public class GetProjectByIdQueryHandlerUnitTest
    {
        [Fact]
        [Trait("Application", "Project - QueryById")]
        public async Task ProjectExist_Executed_ReturnProjectDetailsOutputModel()
        {
            // Arrange
            var client = new User("clientFullName", "client@example.com", new DateTime(1990, 1, 1), "client_password", "Client");
            var freelancer = new User("freelancerFullName", "freelancer@example.com", new DateTime(1995, 5, 5), "freelancer_password", "Freelancer");

            var project = new Project("Title", "Description", 10, client.Id, freelancer.Id);
            project.Start();
            project.Finish();

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(p => p.GetByIdAsync(project.Id)).ReturnsAsync(project);

            var getProjectByIdQuery = new GetProjectByIdQuery(project.Id);
            var getProjectByIdQueryHandler = new GetProjectByIdQueryHandler(projectRepositoryMock.Object);

            // Act
            var projectDetailsOutputModel = await getProjectByIdQueryHandler.Handle(getProjectByIdQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectDetailsOutputModel);
            projectRepositoryMock.Verify(p => p.GetByIdAsync(project.Id), Times.Once);
        }


    }
}
