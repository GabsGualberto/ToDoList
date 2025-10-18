using MediatR;
using System.Xml.Linq;
using ToDoList.Domain.Enum;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.CreateAssignment
{
    public class CreateAssignmentRequest : IRequest<Guid>
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Priority Priority { get; set; }
        public AssignmentStatus Status { get; set; }
    }

    public class CreateAssignmentHandler : IRequestHandler<CreateAssignmentRequest, Guid>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public CreateAssignmentHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }
        public async Task<Guid> Handle(CreateAssignmentRequest request, CancellationToken cancellationToken)
        {
            Guid id = _assignmentRepository.CreateTask(request.Name, request.Description, request.Priority, request.Deadline);
            return id;
        }
    }

}

