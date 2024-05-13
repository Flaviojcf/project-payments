using Expert.Infrastructure.Persistance;
using MediatR;

namespace Expert.Application.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler(ExpertDbContext dbContext) : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly ExpertDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project?.Cancel();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
