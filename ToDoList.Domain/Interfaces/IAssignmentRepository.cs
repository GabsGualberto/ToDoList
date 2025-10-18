using ToDoList.Domain.Entities;
using ToDoList.Domain.Enum;

namespace ToDoList.Domain.Interfaces
{
    public interface IAssignmentRepository
    {
        Guid CreateTask(string name, string description, Priority priority, DateTime deadline);
    }
}
