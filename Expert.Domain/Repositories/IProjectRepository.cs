using Expert.Domain.Entities;

namespace Expert.Domain.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task SaveChangesAsync();
        Task AddCommentAsync(ProjectComment comment);
    }
}
