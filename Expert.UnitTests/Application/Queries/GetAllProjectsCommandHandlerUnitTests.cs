using Expert.Application.Queries.GetAllProjects;
using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Moq;

namespace Expert.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerUnitTests
    {

        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectOutputModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                    new Project("Nome", "Descrição", 10, 1, 2),
                    new Project("Nome", "Descrição2", 20, 1, 2),
                    new Project("Nome", "Descrição3", 20, 1, 2),
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(p => p.GetAllAsync().Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            // Act

            var projectOutputModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectOutputModelList);
            Assert.NotEmpty(projectOutputModelList);
            Assert.Equal(projects.Count, projectOutputModelList.Count);

            projectRepositoryMock.Verify(p => p.GetAllAsync().Result, Times.Once);
        }
    }
}
