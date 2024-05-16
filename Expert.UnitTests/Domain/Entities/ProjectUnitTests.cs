using Expert.Domain.Entities;
using Expert.Domain.Enums;

namespace Expert.UnitTests.Domain.Entities
{
    public class ProjectUnitTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Nome", "Descrição", 10, 1, 2);

            Assert.Equal(ProjecStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);


            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);


            project.Start();

            Assert.Equal(ProjecStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
        }

    }
}
