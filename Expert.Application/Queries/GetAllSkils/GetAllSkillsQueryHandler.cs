using Expert.Application.OutPutModels;
using Expert.Domain.Repositories;
using MediatR;

namespace Expert.Application.Queries.GetAllSkils
{
    public class GetAllSkillsQueryHandler(ISkillsRepository skillsRepository) : IRequestHandler<GetAllSkillsQuery, List<SkillOutputModel>>
    {
        private readonly ISkillsRepository _skillsRepository = skillsRepository;

        public async Task<List<SkillOutputModel>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillsRepository.GetAllAsync();

            var skillsOutputModel = skills.Select(s => new SkillOutputModel(s.Id, s.Description)).ToList();

            return skillsOutputModel;
        }

    }
}
