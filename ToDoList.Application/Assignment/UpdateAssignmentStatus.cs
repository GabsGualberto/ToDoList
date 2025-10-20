using MediatR;
using ToDoList.Domain.Enum;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Assignment
{
    public class UpdateAssignmentStatusRequest : IRequest
    {
        public Guid Id { get; set; }
        public AssignmentStatus Status { get; set; }
    }

    public class UpdateAssignmentStatusHandler : IRequestHandler<UpdateAssignmentStatusRequest>
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public UpdateAssignmentStatusHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }
        public async Task Handle(UpdateAssignmentStatusRequest request, CancellationToken cancellationToken)
        {
            await _assignmentRepository.UpdateAssignmentStatus(request.Id, request.Status);
        }
    }
}