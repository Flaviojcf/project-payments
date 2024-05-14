using Expert.Domain.Entities;
using Expert.Domain.Repositories;
using MediatR;

namespace Expert.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler(IProjectRepository projectRepository) : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository = projectRepository;

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.TotalCost, request.IdCliente, request.IdFreelancer);

            await _projectRepository.AddAsync(project);

            return project.Id;
        }
    }
}
