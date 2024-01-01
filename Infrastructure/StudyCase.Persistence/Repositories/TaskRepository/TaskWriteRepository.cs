using StudyCase.Application.Repositories.TaskRepository;
using StudyCase.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Persistence.Repositories.TaskRepository
{
    public class TaskWriteRepository : WriteRepository<Domain.Entities.Task>, ITaskWriteRepository
    {
        public TaskWriteRepository(StudyCaseDbContext context) : base(context)
        {
        }
    }
}
