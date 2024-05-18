using Expert.Application.Queries.GetAllProjects;
using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Moq;

namespace Expert.UnitTests.Application.Queries
{
    [Collection(nameof(GetAllProjectsQueryHandler))]
    public class GetAllProjectsQueryHandlerUnitTests
    {

        [Fact]
        [Trait("Application", "Project - Query")]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectOutputModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                    new Project("Name", "Description", 10, 1, 2),
                    new Project("Name", "Description2", 20, 1, 2),
                    new Project("Name", "Description3", 20, 1, 2),
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(p => p.GetAllAsync()).ReturnsAsync(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            // Act

            var projectOutputModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectOutputModelList);
            Assert.NotEmpty(projectOutputModelList);
            Assert.Equal(projects.Count, projectOutputModelList.Count);

            projectRepositoryMock.Verify(p => p.GetAllAsync(), Times.Once);
        }
    }
}
