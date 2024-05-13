using MediatR;

namespace Expert.Application.Commands.DeleteProject
{
    public class DeleteProjectCommand(int id) : IRequest<Unit>
    {
        public int Id { get; private set; } = id;
    }
}
