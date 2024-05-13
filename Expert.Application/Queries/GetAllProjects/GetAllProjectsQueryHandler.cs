using Expert.Application.OutPutModels;
using Expert.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Expert.Application.Queries.GetAllProjects
{
    internal class GetAllProjectsQueryHandler(ExpertDbContext dbContext) : IRequestHandler<GetAllProjectsQuery, List<ProjectOutputModel>>
    {
        private readonly ExpertDbContext _dbContext = dbContext;
        public async Task<List<ProjectOutputModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _dbContext.Projects;

            var projectsOutPut = await projects.Select(p => new ProjectOutputModel(p.Id, p.Title, p.CreatedAt)).ToListAsync();

            return projectsOutPut;
        }
    }
}
