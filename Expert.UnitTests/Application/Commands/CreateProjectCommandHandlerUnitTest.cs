using Expert.Application.Commands.CreateProject;
using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Moq;

namespace Expert.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerUnitTest
    {

        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepositoryMock = new Mock<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Title",
                Description = "Description",
                TotalCost = 100,
                IdCliente = 1,
                IdFreelancer = 2
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projectRepositoryMock.Object);

            //Act

            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert

            Assert.True(id >= 0);
            projectRepositoryMock.Verify(p => p.AddAsync(It.IsAny<Project>()), Times.Once);
        }
    }
}
