using Expert.Application.OutPutModels;
using Expert.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Expert.Application.Queries.GetAllSkils
{
    public class GetAllSkillsQueryHandler(ExpertDbContext dbContext) : IRequestHandler<GetAllSkilsQuery, List<SkillOutputModel>>
    {
        private readonly ExpertDbContext _dbContext = dbContext;

        public async Task<List<SkillOutputModel>> Handle(GetAllSkilsQuery request, CancellationToken cancellationToken)
        {
            var skills = _dbContext.Skills;

            var skillsOutputModel = await skills.Select(s => new SkillOutputModel(s.Id, s.Description)).ToListAsync();

            return skillsOutputModel;
        }

    }
}
