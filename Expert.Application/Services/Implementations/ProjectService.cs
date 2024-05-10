using Expert.Application.InputModels;
using Expert.Application.OutPutModels;
using Expert.Application.Services.Interfaces;
using Expert.Domain.Entities;
using Expert.Infrastructure.Persistance;

namespace Expert.Application.Services.Implementations
{
    public class ProjectService(ExpertDbContext dbContext) : IProjectService
    {
        private readonly ExpertDbContext _dbContext = dbContext;

        public int Create(CreateProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.TotalCost, inputModel.IdCliente, inputModel.IdFreelancer);

            _dbContext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbContext.Comments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project?.Cancel();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project?.Finish();
        }

        public List<ProjectOutputModel> GetAll(string query)
        {
            var projects = _dbContext.Projects;

            var projectsOutPut = projects.Select(p => new ProjectOutputModel(p.Id, p.Title, p.CreatedAt)).ToList();

            return projectsOutPut;
        }

        public ProjectDetailsOutputModel GetById(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);


            if (project == null) return null;

            var projectDetailsOutputModel = new ProjectDetailsOutputModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt
                );

            return projectDetailsOutputModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == id);

            project?.Start();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(inputModel.Title, inputModel.Description, inputModel.TotalCost);
        }
    }
}
