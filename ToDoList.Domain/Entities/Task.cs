using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Entities
{
    public class Task
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        
    }
}
