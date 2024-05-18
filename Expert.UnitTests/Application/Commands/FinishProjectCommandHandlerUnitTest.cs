using Expert.Application.Commands.FinishProject;
using Expert.Domain.Repositories;
using Moq;

namespace Expert.UnitTests.Application.Commands
{
    [Collection(nameof(FinishProjectCommand))]
    public class FinishProjectCommandHandlerUnitTest
    {
        [Fact]
        [Trait("Application", "FinishProject - Command")]
        public async Task InputDataIsOk_Executed_ReturnOk()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();

            var id = 1;

            var finishProjectCommand = new FinishProjectCommand(id);

            var finishProjectCommandHandler = new FinishProjectCommandHandler(projectRepository.Object);

            //Act
            await finishProjectCommandHandler.Handle(finishProjectCommand, new CancellationToken());


            //Assert
            projectRepository.Verify(p => p.SaveChangesAsync(), Times.Once);

        }
    }
}
