using Expert.Application.Commands.DeleteProject;
using Expert.Domain.Repositories;
using Moq;

namespace Expert.UnitTests.Application.Commands
{
    [Collection(nameof(DeleteProjectCommand))]
    public class DeleteProjectCommandHandlerUnitTest
    {
        [Fact]
        [Trait("Application", "DeleteProject - Command")]
        public async Task InputDataIsOk_Executed_ReturnOk()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();

            var id = 1;

            var deleteProjectCommand = new DeleteProjectCommand(id);

            var deleteProjectCommandHandler = new DeleteProjectCommandHandler(projectRepository.Object);

            //Act
            await deleteProjectCommandHandler.Handle(deleteProjectCommand, new CancellationToken());


            //Assert
            projectRepository.Verify(p => p.SaveChangesAsync(), Times.Once);

        }
    }
}
