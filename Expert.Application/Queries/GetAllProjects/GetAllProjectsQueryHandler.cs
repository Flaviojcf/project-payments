using Expert.Application.OutPutModels;
using Expert.Domain.Repositories;
using MediatR;

namespace Expert.Application.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler(IProjectRepository projectRepository) : IRequestHandler<GetAllProjectsQuery, List<ProjectOutputModel>>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;
        public async Task<List<ProjectOutputModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetAllAsync();

            var projectsOutPut = projects.Select(p => new ProjectOutputModel(p.Id, p.Title, p.CreatedAt)).ToList();

            return projectsOutPut;
        }
    }
}
