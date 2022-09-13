using MediatR;
using Microsoft.AspNetCore.Mvc;
using Schooly.Domain.Commands;
using Schooly.Domain.Queries;


namespace Schooly.Controllers
{
    [ApiController]
    [Route(Routes.Students)]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromServices] IMediator mediator
         )
        {

            return Ok(await mediator.Send(new GetStudentsListQuery()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(
            [FromServices] IMediator mediator,
            [FromRoute] int id
         )
        {

            return Ok(await mediator.Send(new GetStudentByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromServices] IMediator mediator,
            [FromBody] CreateStudentCommand command
        )
        {
            if (ModelState.IsValid)
            {
                return Ok(await mediator.Send(command));
            }
            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            [FromServices] IMediator mediator,
            [FromBody] UpdateStudentCommand command,
            [FromRoute] int Id
        )
        {
            if (ModelState.IsValid)
            {
                command.Id = Id;
                return Ok(await mediator.Send(command));
            }
            return BadRequest();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            [FromServices] IMediator mediator,
            [FromRoute] int id
        )
        {
            if (ModelState.IsValid)
            {
                
                return Ok(await mediator.Send(new DeleteStudentCommand(id)));
            }
            return BadRequest();
        }
    }
}
