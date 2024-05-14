using Expert.Domain.Entities;

namespace Expert.Domain.Repositories
{
    public interface ISkillsRepository
    {
        Task<List<Skill>> GetAllAsync();
    }
}
