using Expert.Application.OutPutModels;

namespace Expert.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectOutputModel> GetAll(string query);
        ProjectDetailsOutputModel GetById(int id);
    }
}
