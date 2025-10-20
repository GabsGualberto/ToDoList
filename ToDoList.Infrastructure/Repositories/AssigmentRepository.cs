using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enum;
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Configuration;

namespace ToDoList.Infrastructure.Repositories
{
    public class AssigmentRepository : IAssignmentRepository
    {
        private readonly AppDbContext _context;

        public AssigmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAssignment(string name, string description, Priority priority, DateTime? deadline)
        {
            var assignment = new Assignment(name, priority, description, deadline);
            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();

            return assignment.Id;
        }

        public async Task DeleteAssignment(Guid id)
        {
            await _context.Assignments.Where(a => a.Id == id).
                ExecuteUpdateAsync(a => a.SetProperty(p => p.Status, AssignmentStatus.Canceled));

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Assignment>> GetAllAssignments()
        {
            var assignments = await _context.Assignments
                .Where(assignment => assignment.Status != AssignmentStatus.Canceled)
                .OrderByDescending(assignment => assignment.Priority)
                .ToListAsync();
            return assignments;
        }

        public async Task<Assignment> GetAssignmentById(Guid id)
        {
            var assignment = await _context.Assignments.FirstOrDefaultAsync(a => a.Id == id);
            if (assignment == null)
            {
                throw new Exception("Assignment not found");
            }
            return assignment;
        }

        public async Task UpdateAssignment(Guid id, string name, string description, Priority priority, DateTime? deadline)
        {
            await _context.Assignments.Where(a => a.Id == id).
                ExecuteUpdateAsync(a => a
                    .SetProperty(p => p.Name, name)
                    .SetProperty(p => p.Description, description)
                    .SetProperty(p => p.Priority, priority)
                    .SetProperty(p => p.Deadline, deadline)
                );
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateAssignmentStatus(Guid id, AssignmentStatus status)
        {
            await _context.Assignments.Where(a => a.Id == id).
                ExecuteUpdateAsync(a => a.SetProperty(p => p.Status, status));
            await _context.SaveChangesAsync();
        }
    }
}
