using Expert.Application.OutPutModels;
using MediatR;

namespace Expert.Application.Queries.GetProjectById
{
    public class GetProjectByIdQuery(int id) : IRequest<ProjectDetailsOutputModel>
    {
        public int Id { get; private set; } = id;
    }
}
