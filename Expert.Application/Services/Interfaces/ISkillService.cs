using Expert.Application.OutPutModels;

namespace Expert.Application.Services.Interfaces
{
    public interface ISkillService
    {
        List<SkillOutputModel> GetAll();
    }
}
