using Expert.Application.Commands.UpdateProject;
using Expert.Domain.Repositories;
using Moq;

namespace Expert.UnitTests.Application.Commands
{
    [Collection(nameof(UpdateProjectCommand))]
    public class UpdateProjectCommandHandlerUnitTest
    {
        [Fact]
        [Trait("Application", "UpdateProject - Command")]
        public async Task InputDataIsOk_Executed_ReturnOk()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();

            var id = 1;

            var updateProjectCommand = new UpdateProjectCommand(id);

            var updateProjectCommandHandler = new UpdateProjectCommandHandler(projectRepository.Object);

            //Act
            await updateProjectCommandHandler.Handle(updateProjectCommand, new CancellationToken());


            //Assert
            projectRepository.Verify(p => p.SaveChangesAsync(), Times.Once);

        }
    }
}
