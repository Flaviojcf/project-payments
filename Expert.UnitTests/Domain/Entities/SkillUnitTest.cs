using Expert.Domain.Entities;

namespace Expert.UnitTests.Domain.Entities
{
    [Collection(nameof(Skill))]
    public class SkillUnitTest
    {
        [Fact]
        [Trait("Domain", "Skill - Aggregates")]
        public void Instatiate()
        {
            //Arrange
            var skill = new Skill(".net");

            //Act


            //Assert
            Assert.NotNull(skill);
            Assert.Equal(".net", skill.Description);
            Assert.True(skill.CreatedAt <= DateTime.Now && skill.CreatedAt >= DateTime.Now.AddSeconds(-10));
        }
    }
}
