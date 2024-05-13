using Expert.Application.Commands.CreateProject;
using Expert.Application.InputModels;
using Expert.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(IProjectService projectService, IMediator mediator) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public IActionResult Get(string query)
        {
            var projects = _projectService.GetAll(query);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if (command.Title.Length > 50) return BadRequest();

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
        {
            if (inputModel.Title.Length > 200) return BadRequest();

            _projectService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);

            return NoContent();
        }


        [HttpPost("{id}/comments")]
        public IActionResult PostComment([FromBody] CreateCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }
    }
}
