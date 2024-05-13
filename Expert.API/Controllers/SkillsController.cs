using Expert.Application.Queries.GetAllSkils;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Expert.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSkilsQuery();

            var skills = await _mediator.Send(query);

            return Ok(skills);
        }
    }
}
