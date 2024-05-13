using MediatR;

namespace Expert.Application.Commands.UpdateProject
{
    public class UpdateProjectCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}
