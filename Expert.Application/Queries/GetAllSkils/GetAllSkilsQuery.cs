using Expert.Application.OutPutModels;
using MediatR;

namespace Expert.Application.Queries.GetAllSkils
{
    public class GetAllSkilsQuery : IRequest<List<SkillOutputModel>>
    {
    }
}
