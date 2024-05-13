using Expert.Application.OutPutModels;
using Expert.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Expert.Application.Queries.GetProjectById
{
    internal class GetProjectByIdQueryHandler(ExpertDbContext dbContext) : IRequestHandler<GetProjectByIdQuery, ProjectDetailsOutputModel>
    {
        private readonly ExpertDbContext _dbContext = dbContext;
        public async Task<ProjectDetailsOutputModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == request.Id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsOutputModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }
    }
}
