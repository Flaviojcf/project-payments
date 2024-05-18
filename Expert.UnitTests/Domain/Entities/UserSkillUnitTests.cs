using Expert.Domain.Entities;

namespace Expert.UnitTests.Domain.Entities
{
    [Collection(nameof(UserSkill))]
    public class UserSkillUnitTests
    {
        [Fact]
        [Trait("Domain", "UserSkill - Aggregates")]
        public void Instatiate()
        {
            //Arrange
            var userSkill = new UserSkill(1, 2);

            //Act


            //Assert
            Assert.NotNull(userSkill);
            Assert.Equal(0, userSkill.Id);
            Assert.Equal(2, userSkill.IdSkill);
            Assert.Equal(1, userSkill.IdUser);

        }
    }
}
