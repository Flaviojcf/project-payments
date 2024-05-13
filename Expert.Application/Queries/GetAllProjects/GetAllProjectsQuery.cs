using Expert.Application.OutPutModels;
using MediatR;

namespace Expert.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQuery(string query) : IRequest<List<ProjectOutputModel>>
    {
        public string Query { get; private set; } = query;
    }
}
