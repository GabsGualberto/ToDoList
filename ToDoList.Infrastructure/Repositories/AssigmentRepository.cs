using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Enum;
using ToDoList.Domain.Interfaces;

namespace ToDoList.Infrastructure.Repositories
{
    public class AssigmentRepository : IAssignmentRepository
    {
        public Guid CreateTask(string name, string description, Priority priority, DateTime deadline)
        {
            return new Assignment(name, priority, deadline, description).Id;
        }
    }
}
