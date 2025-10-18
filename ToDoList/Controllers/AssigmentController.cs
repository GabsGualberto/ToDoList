using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.CreateAssignment;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssigmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AssigmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateAssigment([FromBody] CreateAssignmentRequest request)
        {
            var result = _mediator.Send(request);
            return CreatedAtAction(nameof(GetAssignmentById), result.Result);
        }

        [HttpGet("{id}")]
        public IActionResult GetAssignmentById(Guid id)
        {
            return Ok();
        }
    }
} 