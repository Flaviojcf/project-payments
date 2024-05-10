using Expert.Application.InputModels;
using Expert.Application.OutPutModels;

namespace Expert.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectOutputModel> GetAll(string query);
        ProjectDetailsOutputModel GetById(int id);
        int Create(CreateProjectInputModel inputModel);
        void Update(UpdateProjectInputModel inputModel);
        void Delete(int id);
        void Start(int id);
        void Finish(int id);
        void CreateComment(CreateCommentInputModel inputModel);
    }
}
