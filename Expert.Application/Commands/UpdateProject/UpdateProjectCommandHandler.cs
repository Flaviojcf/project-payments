using Expert.Infrastructure.Persistance;
using MediatR;

namespace Expert.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler(ExpertDbContext dbContext) : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly ExpertDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Update(request.Title, request.Description, request.TotalCost);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
