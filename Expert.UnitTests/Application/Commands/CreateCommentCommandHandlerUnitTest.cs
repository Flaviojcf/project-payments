using Expert.Application.Commands.CreateComment;
using Expert.Application.Commands.CreateProject;
using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Moq;

namespace Expert.UnitTests.Application.Commands
{
    [Collection(nameof(CreateCommentCommand))]
    public class CreateCommentCommandHandlerUnitTest
    {
        [Fact]
        [Trait("Application", "Comment - Command")]
        public async Task InputDataIsOk_Executed_ReturnOk()
        {
            //Arrange
            var projectRepository = new Mock<IProjectRepository>();

            var createCommentCommand = new CreateCommentCommand
            {
                Content = "content",
                IdProject = 1,
                IdUser = 2
            };
            var createCommentCommandHandler = new CreateCommentCommandHandler(projectRepository.Object);

            //Act
            await createCommentCommandHandler.Handle(createCommentCommand, new CancellationToken());


            //Assert
            projectRepository.Verify(u => u.AddCommentAsync(It.IsAny<ProjectComment>()), Times.Once);

        }
    }
}
