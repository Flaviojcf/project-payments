using Expert.Application.OutPutModels;
using MediatR;

namespace Expert.Application.Queries.GetAllSkils
{
    public class GetAllSkillsQuery : IRequest<List<SkillOutputModel>>
    {
    }
}
