using Expert.Domain.Entities;

namespace Expert.UnitTests.Domain.Entities
{
    [Collection(nameof(ProjectComment))]
    public class ProjectCommentUnitTest
    {
        [Fact]
        [Trait("Domain", "ProjectComment - Aggregates")]
        public void Instatiate()
        {
            //Arrange
            var projectComment = new ProjectComment("content", 1, 2);

            //Act


            //Assert
            Assert.NotNull(projectComment);
            Assert.Equal(0, projectComment.Id);
            Assert.Equal("content", projectComment.Content);
            Assert.True(projectComment.CreatedAt <= DateTime.Now && projectComment.CreatedAt >= DateTime.Now.AddSeconds(-10));
            Assert.Equal(1, projectComment.IdProject);
            Assert.Equal(2, projectComment.IdUser);
            Assert.Null(projectComment.Project);
            Assert.Null(projectComment.User);
        }
    }
}
