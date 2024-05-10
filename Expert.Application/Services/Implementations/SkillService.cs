using Expert.Application.OutPutModels;
using Expert.Application.Services.Interfaces;
using Expert.Infrastructure.Persistance;

namespace Expert.Application.Services.Implementations
{
    public class SkillService(ExpertDbContext dbContext) : ISkillService
    {
        private readonly ExpertDbContext _dbContext = dbContext;
        public List<SkillOutputModel> GetAll()
        {
            var skills = _dbContext.Skills;

            var skillsOutputModel = skills.Select(s => new SkillOutputModel(s.Id, s.Description)).ToList();

            return skillsOutputModel;
        }
    }
}
