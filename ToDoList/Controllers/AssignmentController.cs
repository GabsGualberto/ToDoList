using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Assignment;
using ToDoList.Application.CreateAssignment;

namespace ToDoList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AssignmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateAssigment([FromBody] CreateAssignmentRequest request)
        {
            var result = _mediator.Send(request);
            return Ok(result.Result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignmentById([FromQuery] GetAssignmentByIdRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAssignments([FromQuery] GetAssignmentsRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAssignmentStatus([FromRoute] Guid id, [FromBody] UpdateAssignmentStatusRequest request)
        {
            request.Id = id;
            await _mediator.Send(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment([FromRoute] DeleteAssignmentRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
} 