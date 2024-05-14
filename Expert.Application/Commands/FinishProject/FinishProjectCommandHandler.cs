using Expert.Domain.Repositories;
using MediatR;

namespace Expert.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;
        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.Id);

            project?.Finish();

            await _projectRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
