using Expert.Application.Commands.StartProject;
using Expert.Domain.Repositories;
using Moq;

namespace Expert.UnitTests.Application.Commands
{
    [Collection(nameof(StartProjectCommand))]
    public class StartProjectCommandHandlerUnitTest
    {
        [Fact]
        [Trait("Application", "StartProject - Command")]
        public async Task InputDataIsOk_Executed_ReturnOk()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();

            var id = 1;

            var startProjectCommand = new StartProjectCommand(id);

            var startProjectCommandHandler = new StartProjectCommandHandler(projectRepository.Object);

            //Act
            await startProjectCommandHandler.Handle(startProjectCommand, new CancellationToken());


            //Assert
            projectRepository.Verify(p => p.SaveChangesAsync(), Times.Once);

        }
    }
}
