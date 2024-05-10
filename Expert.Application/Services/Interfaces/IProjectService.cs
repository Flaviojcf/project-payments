using Expert.Application.InputModels;
using Expert.Application.OutPutModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
