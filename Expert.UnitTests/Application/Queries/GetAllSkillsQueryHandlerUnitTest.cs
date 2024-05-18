using Expert.Application.Queries.GetAllSkils;
using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using Moq;

namespace Expert.UnitTests.Application.Queries
{
    [Collection(nameof(GetAllSkillsQuery))]
    public class GetAllSkillsQueryHandlerUnitTest
    {
        [Fact]
        [Trait("Application", "Skill - Query")]
        public async Task SkillsExist_Executed_ReturnSkillOutputModels()
        {
            //Arrange
            var skills = new List<Skill>
            {
                new Skill(".Net"),
                new Skill("Typescript"),
                new Skill("Javascript"),
                new Skill("Nodejs"),
            };

            var skillRepositoryMock = new Mock<ISkillsRepository>();
            skillRepositoryMock.Setup(s => s.GetAllAsync()).ReturnsAsync(skills);

            var getAlSkillsQuery = new GetAllSkillsQuery();
            var getAlSkillsQueryHandler = new GetAllSkillsQueryHandler(skillRepositoryMock.Object);

            // Act

            var skillsOutputModelList = await getAlSkillsQueryHandler.Handle(getAlSkillsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(skillsOutputModelList);
            Assert.NotEmpty(skillsOutputModelList);
            Assert.Equal(skills.Count, skillsOutputModelList.Count);

            skillRepositoryMock.Verify(p => p.GetAllAsync(), Times.Once);
        }
    }
}
