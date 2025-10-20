using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Assignment
{
    public class DeleteAssignmentRequest : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteAssignmentHandler : IRequestHandler<DeleteAssignmentRequest>
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public DeleteAssignmentHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task Handle(DeleteAssignmentRequest request, CancellationToken cancellationToken)
        {
             await _assignmentRepository.DeleteAssignment(request.Id);
        }
    }
}
