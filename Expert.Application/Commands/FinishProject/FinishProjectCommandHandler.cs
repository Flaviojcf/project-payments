using Expert.Infrastructure.Persistance;
using MediatR;

namespace Expert.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler(ExpertDbContext dbContext) : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly ExpertDbContext _dbContext = dbContext;
        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project?.Finish();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
