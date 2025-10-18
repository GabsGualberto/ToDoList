using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Enum
{
    public enum TaskStatus
    {
        Canceled = -1,
        Backlog,
        Doing,
        Complete
    }
}
