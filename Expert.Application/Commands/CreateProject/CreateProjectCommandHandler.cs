using Expert.Domain.Entities;
using Expert.Infrastructure.Persistance;
using MediatR;

namespace Expert.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler(ExpertDbContext dbContext) : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly ExpertDbContext _dbContext = dbContext;

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.TotalCost, request.IdCliente, request.IdFreelancer);

            await _dbContext.Projects.AddAsync(project);

            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
