using MediatR;
using ToDoList.Domain.Interfaces;


namespace ToDoList.Application.Assignment
{
    public class GetAssignmentsRequest : IRequest<IEnumerable<Domain.Entities.Assignment>>
    {
    }
    public class GetAssignmentsHandler : IRequestHandler<GetAssignmentsRequest, IEnumerable<Domain.Entities.Assignment>>
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public GetAssignmentsHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Assignment>> Handle(GetAssignmentsRequest request, CancellationToken cancellationToken)
        {
            return await _assignmentRepository.GetAllAssignments();
        }
    }
}
