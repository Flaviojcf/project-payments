using Expert.Application.OutPutModels;
using Expert.Domain.Repositories;
using MediatR;

namespace Expert.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler(IProjectRepository projectRepository) : IRequestHandler<GetProjectByIdQuery, ProjectDetailsOutputModel>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;
        public async Task<ProjectDetailsOutputModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsOutputModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client?.FullName,
                project.Freelancer?.FullName
                );

            return projectDetailsViewModel;
        }
    }
}
