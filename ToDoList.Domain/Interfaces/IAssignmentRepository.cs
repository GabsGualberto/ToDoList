using ToDoList.Domain.Entities;
using ToDoList.Domain.Enum;

namespace ToDoList.Domain.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<Guid> CreateAssignment(string name, string description, Priority priority, DateTime? deadline);
        Task UpdateAssignmentStatus(Guid id, AssignmentStatus status);
        Task UpdateAssignment(Guid id, string name, string description, Priority priority, DateTime? deadline);
        Task<Assignment> GetAssignmentById(Guid id);
        Task<IEnumerable<Assignment>> GetAllAssignments();
        Task DeleteAssignment(Guid id);
    }
}
