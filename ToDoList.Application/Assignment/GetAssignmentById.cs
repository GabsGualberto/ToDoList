using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Application.Assignment
{
    public class GetAssignmentByIdRequest : IRequest<Domain.Entities.Assignment>
    {
        public Guid Id { get; set; }
    }

    public class GetAssignmentByIdHandler : IRequestHandler<GetAssignmentByIdRequest, Domain.Entities.Assignment>
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public GetAssignmentByIdHandler(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<Domain.Entities.Assignment> Handle(GetAssignmentByIdRequest request, CancellationToken cancellationToken)
        {
            return await _assignmentRepository.GetAssignmentById(request.Id);
        }
    }
}
