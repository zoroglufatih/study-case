using StudyCase.Application.Repositories.TaskRepository;
using StudyCase.Domain.Entities;
using StudyCase.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Persistence.Repositories.TaskRepository
{
    public class TaskReadRepository : ReadRepository<Domain.Entities.Task>, ITaskReadRepository
    {
        public TaskReadRepository(StudyCaseDbContext context) : base(context)
        {
        }
    }
}
