using System.Data;
using ToDoList.Domain.Enum;

namespace ToDoList.Domain.Entities
{
    public class Assignment
    {
        public Guid Id { get; private set; }
        public string? Name { get;  set; }
        public string? Description { get;  set; }
        public AssignmentStatus Status { get; private set; }
        public Priority Priority { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime Deadline { get; private set; }
        public DateTime? ModifiedAt { get; private set; }


        public Assignment() { }

        public Assignment(string name, Priority priority, DateTime deadline, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Status = AssignmentStatus.InProgress;
            Priority = priority;
            Deadline = deadline;
            Description = description;
        }

        public void UpdateStatus(AssignmentStatus status)
        {
            Status = status;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}
