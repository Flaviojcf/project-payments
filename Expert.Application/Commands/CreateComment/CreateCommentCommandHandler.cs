using Expert.Application.Commands.CreateProject;
using Expert.Domain.Entities;
using Expert.Infrastructure.Persistance;
using MediatR;

namespace Expert.Application.Commands.CreateComment
{
    internal class CreateCommentCommandHandler(ExpertDbContext dbContext) : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly ExpertDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _dbContext.Comments.AddAsync(comment);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
