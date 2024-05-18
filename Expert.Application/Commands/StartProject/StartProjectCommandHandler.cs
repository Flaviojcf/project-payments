using Expert.Domain.Repositories;
using MediatR;

namespace Expert.Application.Commands.StartProject
{
    public class StartProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            project?.Start();

            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
