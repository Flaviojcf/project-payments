using Expert.Domain.Entities;
using Expert.Domain.Enums;

namespace Expert.UnitTests.Domain.Entities
{
    [Collection(nameof(Project))]
    public class ProjectUnitTests
    {
        [Fact]
        [Trait("Domain", "Project - Aggregates")]
        public void Instatiate()
        {
            //Arrange
            var project = new Project("Nome", "Descrição", 10, 1, 2);

            //Act


            //Assert
            Assert.NotNull(project);
            Assert.Null(project.Client);
            Assert.NotNull(project.Comments);
            Assert.True(project.CreatedAt <= DateTime.Now && project.CreatedAt >= DateTime.Now.AddSeconds(-10));
            Assert.Equal("Descrição", project.Description);
            Assert.Null(project.FinishedAt);
            Assert.Null(project.Freelancer);
            Assert.Equal(0, project.Id);
            Assert.Equal(1, project.IdClient);
            Assert.Equal(2, project.IdFreelancer);
            Assert.Null(project.StartedAt);
            Assert.Equal(ProjecStatusEnum.Created, project.Status);
            Assert.Equal("Nome", project.Title);
            Assert.Equal(10, project.TotalCost);
        }

        [Fact]
        [Trait("Domain", "Project  - Aggregates")]
        public void TestIfProjectStartWorks()
        {
            //Arrange
            var project = new Project("Nome", "Descrição", 10, 1, 2);

            //Act
            project.Start();

            //Assert
            Assert.Equal(ProjecStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }

        [Fact]
        [Trait("Domain", "Project - Aggregates")]
        public void TestIfProjectCancelWorks()
        {
            //Arrange
            var project = new Project("Nome", "Descrição", 10, 1, 2);

            //Act
            project.Cancel();

            //Assert
            Assert.Equal(ProjecStatusEnum.Cancelled, project.Status);
        }

        [Fact]
        [Trait("Domain", "Project - Aggregates")]
        public void TestIfProjectFinishWorks()
        {
            //Arrange
            var project = new Project("Nome", "Descrição", 10, 1, 2);

            //Act
            project.Start();
            project.SetPaymentPending();
            project.Finish();

            //Assert
            Assert.Equal(ProjecStatusEnum.Finished, project.Status);
        }

        [Fact]
        [Trait("Domain", "Project - Aggregates")]
        public void TestIfProjectUpdateWorks()
        {
            //Arrange
            var project = new Project("Nome", "Descrição", 10, 1, 2);

            //Act
            project.Update("NewName", "NewDescription", 20);

            //Assert
            Assert.Equal("NewName", project.Title);
            Assert.Equal("NewDescription", project.Description);
            Assert.Equal(20, project.TotalCost);
        }

    }
}
