using System.Data;
using ToDoList.Domain.Enum;

namespace ToDoList.Domain.Entities
{
    public class Assignment
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AssignmentStatus Status { get; private set; }
        public Priority Priority { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? Deadline { get; private set; }
        public DateTime? ModifiedAt { get; private set; }


        public Assignment() { }

        public Assignment(string name, Priority priority, string description, DateTime? deadline)
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
