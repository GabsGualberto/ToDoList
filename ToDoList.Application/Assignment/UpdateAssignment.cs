using MediatR;
using ToDoList.Domain.Enum;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Assignment
{
    public class UpdateAssignmentRequest: IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Priority Priority { get; set; }
        public AssignmentStatus Status { get; set; }
    }

    public class UpdateAssignmentHandler : IRequestHandler<UpdateAssignmentRequest>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public UpdateAssignmentHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }
        public async Task Handle(UpdateAssignmentRequest request, CancellationToken cancellationToken)
        {
           await _assignmentRepository.UpdateAssignment(request.Id, request.Name, request.Description, request.Priority, request.Deadline);
        }
    }
}