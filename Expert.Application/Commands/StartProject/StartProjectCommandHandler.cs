using Expert.Infrastructure.Persistance;
using MediatR;

namespace Expert.Application.Commands.StartProject
{
    public class StartProjectCommandHandler(ExpertDbContext dbContext) : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly ExpertDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project?.Start();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
